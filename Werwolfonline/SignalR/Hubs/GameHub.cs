using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using werwolfonline.Database.Model;
using werwolfonline.Database.Repositories;
using werwolfonline.Models.Enums;
using werwolfonline.SignalR.Clients;
using werwolfonline.SignalR.Model;

namespace werwolfonline.SignalR.Hubs
{
    public class GameHub : Hub<IClient>
    {

        private GameRepository gameRepository;
        private PlayerRepository playerRepository;
        private readonly ILogger<GameHub> logger;

        public GameHub(GameRepository gameRepository, PlayerRepository playerRepository, ILogger<GameHub> logger) : base()
        {
            this.gameRepository = gameRepository;
            this.playerRepository = playerRepository;
            this.logger = logger;
        }

        public async Task JoinGame(string gameNumber, string name)
        {
            var game = await gameRepository.GetByGameNumber(gameNumber);
            if (game == null)
            {
                await Clients.Caller.NotFound();
            }
            else if (game.Phase != Phase.WaitForPlayers)
            {
                await Clients.Caller.NotAuthorized();
            }
            else
            {
                var player = await playerRepository.Add(new Player(name, Context.ConnectionId, game));
                var publicGame = new PublicGame(game, player);
                var allPlayers = await playerRepository.GetPlayersForGame(game.Id);
                System.Console.WriteLine(string.Join(", ", allPlayers.Select(player => player.ConnectionId)));
                await Clients.Clients(allPlayers.Select(player => player.ConnectionId).ToList()).SendGameUpdate(publicGame);
            }
        }

        public async Task CreateGame(string name)
        {
            var game = await gameRepository.Add(new Game() { Phase = Phase.WaitForPlayers }.AddCharacterCounts());
            var player = await playerRepository.Add(new Player(name, Context.ConnectionId, game) { IsHost = true });
            var publicGame = game.GetPublicGame(player);
            await Clients.Caller.SendGameUpdate(publicGame);
        }

        public async Task StartSetup()
        {
            var callingPlayer = await playerRepository.GetByConnectionId(Context.ConnectionId);
            if (callingPlayer == null)
            {
                await Clients.Caller.NotFound();
                return;
            }
            if (!callingPlayer.IsHost)
            {
                await Clients.Caller.NotAuthorized();
                return;
            }
            await gameRepository.SetPhase(callingPlayer.Game, Phase.Setup);
            var players = await playerRepository.GetPlayersForGame(callingPlayer.GameId);
            foreach (var player in players)
            {
                await Clients.Client(player.ConnectionId).SendGameUpdate(callingPlayer.Game.GetPublicGame(player));
            }
        }

        public async Task StartGame(PublicGame game)
        {
            var caller =await playerRepository.GetByConnectionId(Context.ConnectionId);
            if(!caller.IsHost || caller.Id!=game.Id){
                await Clients.Caller.NotAuthorized();
                return;
            }
            await gameRepository.SetCharacterCounts(caller.Game, game.CharacterCounts);
            var players = await playerRepository.GetPlayersForGame(caller.GameId);
            await playerRepository.AssignRoles(players, caller.Game.CharacterCounts);
            await gameRepository.SetPhase(caller.Game, Phase.NightAmor);
            foreach(var player in players){
                await Clients.Client(player.ConnectionId).SendGameUpdate(caller.Game.GetPublicGame(player));
            }
        }

        public async Task LoadPlayer(int playerId, string secret)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null)
            {
                if (player.Secret == secret)
                {
                    player.ConnectionId = Context.ConnectionId;
                    await Clients.Caller.SendPlayerUpdate(player.GetPublicPlayer());
                }
                else
                {
                    await Clients.Caller.NotAuthorized();
                }
            }
            else
            {
                await Clients.Caller.NotFound();
            }
        }

        public async Task NewPlayer(string name, int gameId)
        {
            var game = await gameRepository.GetById(gameId);
            if (game == null)
            {
                await Clients.Caller.NotFound();
                return;
            }
            var player = new Player(name, Context.ConnectionId, game);
            await playerRepository.Add(player);
            await Clients.Caller.SendPlayerUpdate(player.GetPublicPlayer());
        }

        public async Task VoteFor(int playerId, string secret, int votedPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player == null || player.Secret != secret || !player.IsAlive) { return; }

            var votedPlayer = await playerRepository.GetById(votedPlayerId);
            if (votedPlayer == null || !votedPlayer.IsAlive || votedPlayer.GameId != player.GameId) { return; }
            player.VoteFor = votedPlayer;
            await EvaluateVote(player.GameId);
        }

        public async Task WitchKill(int playerId, string secret, int killedPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player == null || player.Secret != secret || player.Character != Character.Witch || !player.IsAlive) { return; }
            var killedPlayer = await playerRepository.GetById(killedPlayerId);
            if (killedPlayer != null && killedPlayer.GameId == player.GameId)
            {
                player.DiedTonight = true;
            }
        }
        public async Task WitchHeal(int playerId, string secret)
        {
            var player = await playerRepository.GetById(playerId);
            if (player == null || player.Secret != secret || player.Character != Character.Witch) { return; }
            var werewolfVictim = await playerRepository.GetWerewolfVictim(player.Game);
            if (werewolfVictim != null)
            {
                player.DiedTonight = false;
            }
        }
        public async Task SeerIdentify(int playerId, string secret, int identifiedPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player == null || player.Secret != secret || player.Character != Character.Seer) { return; }

            var identifiedPlayer = await playerRepository.GetById(identifiedPlayerId);
            if (identifiedPlayer == null || !identifiedPlayer.IsAlive || identifiedPlayer.GameId != player.GameId) { return; }

            var character = Models.Characters.Character.GetCharacterById(identifiedPlayer.Character);

            if (player.Game.SeerSeesIdentity)
            {
                await Clients.Caller.RevealIdentity(character.Name);
            }
            else
            {
                await Clients.Caller.RevealIdentity(character.LooksLikeWerewolf ? "Werwolf" : "Dorfbewohner");
            }
        }

        public async Task HunterShoots(int playerId, string secret, int shotPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player == null || player.Secret != secret || player.Character != Character.Hunter) { return; }

            var shotPlayer = await playerRepository.GetById(shotPlayerId);
            if (shotPlayer != null && shotPlayer.IsAlive && shotPlayer.GameId == player.GameId && player.LoverId != shotPlayer.Id)
            {
                await Kill(shotPlayer);
            }
        }

        public async Task AmorCouples(int playerId, string secret, int lover1Id, int lover2Id)
        {
            var player = await playerRepository.GetById(playerId);
            if (player == null || player.Secret != secret || player.Character != Character.Amor) { return; }

            var lover1 = await playerRepository.GetById(lover1Id);
            var lover2 = await playerRepository.GetById(lover2Id);
            if (lover1 != null && lover2 != null && lover1.GameId == player.GameId && lover2.GameId == player.GameId)
            {
                lover1.Lover = lover2;
                lover2.Lover = lover1;
                await Clients.Client(lover1.ConnectionId).InformLover(lover2.Id);
                await Clients.Client(lover2.ConnectionId).InformLover(lover1.Id);
            }
        }

        public async Task SlutChooses(int playerId, string secret, int otherPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player == null || player.Secret != secret || player.Character != Character.Slut) { return; }

            var otherPlayer = await playerRepository.GetById(otherPlayerId);
            if (otherPlayer != null && otherPlayer.IsAlive && otherPlayer.GameId == player.GameId)
            {
                if (otherPlayer.IsWerewolf)
                {
                    await playerRepository.SetDiedTonight(player, true);
                }
                else
                {
                    await playerRepository.SetAssociate(player, otherPlayer);
                }
            }
        }



        public async Task Ready(int playerId, string secret)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null && player.Secret == secret)
            {
                player.IsReady = true;
            }
        }

        private async Task Kill(Player player)
        {
            if (player.Lover != null)
            {
                await Kill(player.Lover);
            }
            if (player.Character == Character.Hunter)
            {
                await Clients.Client(player.ConnectionId).AskHunter();
                var otherPlayers = (await playerRepository.GetPlayersForGame(player.GameId))
                    .Where(p => p.ConnectionId != player.ConnectionId)
                    .Select(p => p.ConnectionId)
                    .ToList();
                await Clients.Clients(otherPlayers).WaitForHunter();
            }
            player.IsAlive = false;
        }

        private async Task EvaluateVote(int gameId)
        {
            var game = await gameRepository.GetById(gameId);
            if (game == null) { return; }

            switch (game.Phase)
            {
                case Phase.NightWolves:
                    var wolves = await playerRepository.GetWerewolves(gameId);
                    var victim = await MarjorityWinner(wolves, gameId);
                    if (victim != null)
                    {
                        await Clients.Clients(wolves.Select(wolf => wolf.ConnectionId).ToList()).GoToSleep();
                        await playerRepository.SetDiedTonight(victim, true);
                    }
                    break;
            }
        }

        private async Task<Player?> MarjorityWinner(IEnumerable<Player> voters, int gameId)
        {
            var voterCount = voters.Count(voter => voter.VoteForId != null);
            // Find the one who has a plurality
            var pluralityWinner = voters
                                    .Where(voter => voter.VoteForId != null)
                                    .Select(voter => voter.VoteForId ?? 0)
                                    .GroupBy(playerId => playerId)
                                    .OrderByDescending(grouping => grouping.Count())
                                    .First();
            if (pluralityWinner.Count() > voterCount / 2)
            {
                return await playerRepository.GetById(pluralityWinner.Key);
            }
            return null;
        }

    }
}