using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using werwolfonline.Database.Model;
using werwolfonline.Models.Enums;

namespace werwolfonline.Database.Repositories
{
    public class PlayerRepository
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

        public async Task<Player> GetVillager(int gameId)
        {
            return await context.Players
                .SingleOrDefaultAsync(player => player.GameId == gameId && player.Character == Character.Villager);
        }

        public async Task<Player> GetAmor(int gameId)
        {
            return await context.Players
                .SingleOrDefaultAsync(player => player.GameId == gameId && player.Character == Character.Amor);
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

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await context.Players.ToListAsync();
        }

        public async Task<int> Count()
        {
            return await context.Players.CountAsync();
        }

        public async Task Add(Player player)
        {
            context.Add(player);
            await context.SaveChangesAsync();
        }

        public async Task ResetPlayer(Player player)
        {
            player.MorningReset();
            await context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}