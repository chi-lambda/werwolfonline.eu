using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using werwolfonline.Database.Model;
using werwolfonline.Database.Repositories;
using werwolfonline.Models.Enums;
using werwolfonline.SignalR.Clients;

namespace werwolfonline.SignalR.Hubs
{
    public class GameHub : Hub<IClient>
    {

        private GameRepository gameRepository;
        private PlayerRepository playerRepository;

        public GameHub(GameRepository gameRepository, PlayerRepository playerRepository) : base()
        {
            this.gameRepository = gameRepository;
            this.playerRepository = playerRepository;
        }

        public async Task LoadPlayer(int playerId, string secret)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null)
            {
                if (player.Secret == secret)
                {
                    player.Connectionid = Context.ConnectionId;
                    await Clients.Caller.SendPlayerUpdate(JsonConvert.SerializeObject(player));
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

        public async Task NewPlayer(string name)
        {
            var player = new Player(name, Context.ConnectionId);
            await playerRepository.Add(player);
            await Clients.Caller.SendPlayerUpdate(JsonConvert.SerializeObject(player));
        }

        public async Task VoteFor(int playerId, string secret, int votedPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null && player.Secret == secret && player.IsAlive)
            {
                var votedPlayer = await playerRepository.GetById(votedPlayerId);
                if (votedPlayer != null && votedPlayer.IsAlive && votedPlayer.GameId == player.GameId)
                {
                    player.VoteFor = votedPlayer;
                }
            }
        }

        public async Task WitchKill(int playerId, string secret, int killedPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null && player.Secret == secret && player.Character == Character.Witch && player.IsAlive)
            {
                var killedPlayer = await playerRepository.GetById(killedPlayerId);
                if (killedPlayer != null && killedPlayer.GameId == player.GameId)
                {
                    await Kill(killedPlayer);
                }
            }
        }
        public async Task WitchHeal(int playerId, string secret)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null && player.Secret == secret && player.Character == Character.Witch)
            {
                var werewolfVictim = await playerRepository.GetWerewolfVictim(player.GameId);
                if (werewolfVictim != null)
                {
                    player.IsAlive = true;
                }

            }
        }
        public async Task SeerIdentify(int playerId, string secret, int identifiedPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null && player.Secret == secret && player.Character == Character.Seer)
            {
                var identifiedPlayer = await playerRepository.GetById(identifiedPlayerId);
                if (identifiedPlayer != null && identifiedPlayer.IsAlive && identifiedPlayer.GameId == player.GameId)
                {
                    var character = Models.Characters.Character.GetCharacterById(identifiedPlayer.Character);
                    var game = await gameRepository.GetById(player.GameId);
                    if (game.SeerSeesIdentity)
                    {
                        await Clients.Caller.RevealIdentity(character.Name);
                    } else
                    {
                        await Clients.Caller.RevealIdentity(character.LooksLikeWerewolf ? "Werwolf" : "Dorfbewohner");
                    }
                }

            }
        }

        public async Task HunterShoots(int playerId, string secret, int shotPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null && player.Secret == secret && player.Character == Character.Hunter)
            {
                var shotPlayer = await playerRepository.GetById(shotPlayerId);
                if (shotPlayer != null && shotPlayer.IsAlive && shotPlayer.GameId == player.GameId && player.LoverId != shotPlayer.Id)
                {
                    await Kill(shotPlayer);
                }
            }
        }

        public async Task AmorCouples(int playerId, string secret, int lover1Id, int lover2Id)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null && player.Secret == secret && player.Character == Character.Amor)
            {
                var lover1 = await playerRepository.GetById(lover1Id);
                var lover2 = await playerRepository.GetById(lover2Id);
                if (lover1 != null && lover2 != null && lover1.GameId == player.GameId && lover2.GameId == player.GameId)
                {
                    lover1.Lover = lover2;
                    lover2.Lover = lover1;
                    await Clients.Client(lover1.Connectionid).InformLover(lover2.Id);
                    await Clients.Client(lover2.Connectionid).InformLover(lover1.Id);
                }
            }
        }

        public async Task SlutChooses(int playerId, string secret, int otherPlayerId)
        {
            var player = await playerRepository.GetById(playerId);
            if (player != null && player.Secret == secret && player.Character == Character.Slut)
            {
                var otherPlayer = await playerRepository.GetById(otherPlayerId);
                if (otherPlayer != null && otherPlayer.IsAlive && otherPlayer.GameId == player.GameId)
                {
                    if (otherPlayer.IsWerewolf){
                        player.IsAlive = false;
                        await Kill(player);
                    }
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

            }
            player.IsAlive = false;
        }

    }
}