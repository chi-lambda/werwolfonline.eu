using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using werwolfonline.Database.Model;
using werwolfonline.Database.Model.Enums;
using werwolfonline.Interfaces.Database.Repositories;
using werwolfonline.Utils;

namespace werwolfonline.Tests.Mocks.Database.Repositories
{
    public class MockPlayerRepository : IPlayerRepository
    {
        public ICollection<Game> Games { get; }
        private ICollection<Player> Players { get; }
        private int currentId = 1;

        private CorrectHorseBatteryStaple chbs = new CorrectHorseBatteryStaple();
        private IRNGesus rnGesus;

        public MockPlayerRepository(ICollection<Game> games, ICollection<Player> players, IRNGesus rnGesus)
        {
            Games = games;
            Players = players;
            this.rnGesus = rnGesus;
        }

        public async Task<Player> Add(Player player)
        {
            player.Id = currentId;
            currentId++;
            Players.Add(player);
            var game = player.Game;
            if (!game.Players.Any(p => p.Id == player.Id))
            {
                game.Players.Add(player);
            }
            return await Task.FromResult(player);
        }

        public async Task<Player> GetById(int id)
        {
            return await Task.FromResult(Players.SingleOrDefault(player => player.Id == id));
        }

        public async Task<List<Player>> GetPlayersForGame(int gameId)
        {
            return await Task.FromResult(Players.Where(player => player.GameId == gameId).ToList());
        }

        public async Task<Player> GetWerewolfVictim(Game game)
        {
            return await Task.FromResult(Players.SingleOrDefault(player => player.Id == game.WerewolfVictimId));
        }

        public async Task<IEnumerable<Player>> GetWerewolves(int gameId)
        {
            return await Task.FromResult(Players
                .Where(player => player.GameId == gameId && player.Character == Character.Werewolf || player.Character == Character.GreatWolf)
                .ToList());
        }

        public async Task<Player> GetWitch(int gameId)
        {
            return await Task.FromResult(Players
                .SingleOrDefault(player => player.GameId == gameId && player.Character == Character.Witch));
        }

        public async Task<Player> GetSlut(int gameId)
        {
            return await Task.FromResult(Players
                .SingleOrDefault(player => player.GameId == gameId && player.Character == Character.Slut));
        }

        public async Task<Player> GetVillagers(int gameId)
        {
            return await Task.FromResult(Players
                .SingleOrDefault(player => player.GameId == gameId && player.Character == Character.Villager));
        }

        public async Task<Player> GetAmor(int gameId)
        {
            return await Task.FromResult(Players
                .SingleOrDefault(player => player.GameId == gameId && player.Character == Character.Amor));
        }

        public async Task<Player> GetSeer(int gameId)
        {
            return await Task.FromResult(Players
                .SingleOrDefault(player => player.GameId == gameId && player.Character == Character.Seer));
        }

        public async Task<Player> GetProtector(int gameId)
        {
            return await Task.FromResult(Players
                .SingleOrDefault(player => player.GameId == gameId && player.Character == Character.Protector));
        }

        public async Task<bool> IsPlayerProtected(int playerId)
        {
            return await Task.FromResult(Players.Any(player => player.Character == Character.Protector && player.AssociateId == playerId));
        }

        public async Task<int> GetWerewolfCount()
        {
            return await Task.FromResult(Players.Count(player => player.Character == Character.GreatWolf || player.Character == Character.Werewolf));
        }

        public async Task<Player> GetByConnectionId(string connectionId)
        {
            return await Task.FromResult(Players.Where(player => player.ConnectionId == connectionId).SingleOrDefault());
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await Task.FromResult(Players.ToList());
        }

        public async Task<int> Count()
        {
            return await Task.FromResult(Players.Count);
        }

        public async Task<int> CountForGame(int gameId)
        {
            return await Task.FromResult(Players.Count(player => player.GameId == gameId && player.IsAlive));
        }
        public async Task<int> CountWolvesForGame(int gameId)
        {
            return await Task.FromResult(Players.Count(player => player.GameId == gameId && player.IsAlive && (player.Character == Character.Werewolf || player.Character == Character.GreatWolf)));
        }

        public async Task SetAssociate(Player player, Player associate)
        {
            player.Associate = associate;
            await Task.CompletedTask;
        }

        public async Task VoteFor(Player voter, Player victim)
        {
            voter.VoteFor = victim;
            await Save();
        }
        public async Task SetDiedTonight(Player player, bool state)
        {
            player.DiedTonight = state;
            await Save();
        }

        public async Task AssignRoles(IEnumerable<Player> players, IEnumerable<CharacterCount> characterCounts)
        {
            while (!players.Any(player => player.Character == Character.Werewolf || player.Character == Character.GreatWolf))
            {
                var characterList = characterCounts
                    .SelectMany(cc => Enumerable.Repeat(cc.Character, cc.Count))
                    .ToList();
                var rnd = new Random();
                foreach (var player in players)
                {
                    var pos = rnd.Next(characterList.Count);
                    player.Character = characterList[pos];
                    characterList.RemoveAt(pos);
                }
            }

            await Save();
        }

        public async Task ResetPlayer(Player player)
        {
            player.MorningReset();
            await Save();
        }

        public async Task Save()
        {
            //NOP
            await Task.CompletedTask;
        }
    }
}