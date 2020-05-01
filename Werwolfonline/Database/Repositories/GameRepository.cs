using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using werwolfonline.Database.Model;
using werwolfonline.Database.Utils;
using werwolfonline.Models.Enums;

namespace werwolfonline.Database.Repositories
{
    public class GameRepository
    {
        private readonly WerewolfContext context;
        private readonly CorrectHorseBatteryStaple chbs;

        public GameRepository(WerewolfContext context, CorrectHorseBatteryStaple chbs)
        {
            this.context = context;
            this.chbs = chbs;
        }

        public async Task<Game> GetById(int id)
        {
            return await context.Games.FindAsync(id);
        }

        public async Task<Game?> GetByGameNumber(string gameNumber)
        {
            ulong gameNumberNumeric;
            if (!ulong.TryParse(gameNumber, out gameNumberNumeric))
            {
                gameNumberNumeric = chbs.FromGermanWords(gameNumber);
            }
            return await context.Games.SingleOrDefaultAsync(game => game.GameNumber == gameNumberNumeric);
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await context.Games.ToListAsync();
        }

        public async Task<int> Count()
        {
            return await context.Games.CountAsync();
        }

        public async Task SetPhase(Game game, Phase phase)
        {
            if (game.Phase == Phase.NightAmor)
            {
                game.Night++;
                if (game.Night > 1)
                {
                    phase = Phase.NightSeer;
                }
            }
            game.Phase = phase;
            await context.SaveChangesAsync();
        }

        public async Task SetCharacterCounts(Game game, IEnumerable<CharacterCount> characterCounts)
        {
            var dict = characterCounts.ToDictionary(k => k.Character, v => v.Count);
            foreach (var cc in game.CharacterCounts)
            {
                cc.Count = dict[cc.Character];
            }
            await context.SaveChangesAsync();
        }

        public async Task<Game> Add(Game game)
        {
            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
            return game;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}