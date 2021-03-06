using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using werwolfonline.Database.Model;
using werwolfonline.Database.Model.Enums;
using werwolfonline.Interfaces.Database.Repositories;

namespace werwolfonline.Database.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly WerewolfContext context;

        public PlayerRepository(WerewolfContext context)
        {
            this.context = context;
        }

        public async Task<Player> GetById(int id)
        {
            return await context.Players.FindAsync(id);
        }

        public async Task<List<Player>> GetPlayersForGame(int gameId)
        {
            return await context.Players.Where(player => player.GameId == gameId).ToListAsync();
        }

        public async Task<Player> GetWerewolfVictim(Game game)
        {
            return await context.Players.FindAsync(game.WerewolfVictimId);
        }

        public async Task<IEnumerable<Player>> GetWerewolves(int gameId)
        {
            return await context.Players
                .Where(player => player.GameId == gameId && player.Character == Character.Werewolf || player.Character == Character.GreatWolf)
                .ToListAsync();
        }

        public async Task<Player> GetWitch(int gameId)
        {
            return await context.Players
                .SingleOrDefaultAsync(player => player.GameId == gameId && player.Character == Character.Witch);
        }

        public async Task<Player> GetSlut(int gameId)
        {
            return await context.Players
                .SingleOrDefaultAsync(player => player.GameId == gameId && player.Character == Character.Slut);
        }

        public async Task<Player> GetVillagers(int gameId)
        {
            return await context.Players
                .SingleOrDefaultAsync(player => player.GameId == gameId && player.Character == Character.Villager);
        }

        public async Task<Player> GetAmor(int gameId)
        {
            return await context.Players
                .SingleOrDefaultAsync(player => player.GameId == gameId && player.Character == Character.Amor);
        }

        public async Task<Player> GetSeer(int gameId)
        {
            return await context.Players
                .SingleOrDefaultAsync(player => player.GameId == gameId && player.Character == Character.Seer);
        }

        public async Task<Player> GetProtector(int gameId)
        {
            return await context.Players
                .SingleOrDefaultAsync(player => player.GameId == gameId && player.Character == Character.Protector);
        }

        public async Task<bool> IsPlayerProtected(int playerId)
        {
            return await context.Players.AnyAsync(player => player.Character == Character.Protector && player.AssociateId == playerId);
        }

        public async Task<int> GetWerewolfCount()
        {
            return await context.Players.CountAsync(player => player.Character == Character.GreatWolf || player.Character == Character.Werewolf);
        }

        public async Task<Player> GetByConnectionId(string connectionId)
        {
            return await context.Players.Where(player => player.ConnectionId == connectionId).Include(player => player.Game).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await context.Players.ToListAsync();
        }

        public async Task<int> Count()
        {
            return await context.Players.CountAsync();
        }

        public async Task<int> CountForGame(int gameId)
        {
            return await context.Players.CountAsync(player => player.GameId == gameId && player.IsAlive);
        }
        public async Task<int> CountWolvesForGame(int gameId)
        {
            return await context.Players.CountAsync(player => player.GameId == gameId && player.IsAlive && (player.Character == Character.Werewolf || player.Character == Character.GreatWolf));
        }

        public async Task SetAssociate(Player player, Player associate)
        {
            player.Associate = associate;
            await Save();
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

        public async Task<Player> Add(Player player)
        {
            context.Add(player);
            await Save();
            return player;
        }

        public async Task ResetPlayer(Player player)
        {
            player.MorningReset();
            await Save();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}