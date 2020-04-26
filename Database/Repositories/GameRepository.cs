using System.Threading.Tasks;
using werwolfonline.Database.Model;

namespace werwolfonline.Database.Repositories
{
    public class GameRepository
    {
        private readonly WerewolfContext context;

        public GameRepository(WerewolfContext context){
            this.context = context;
        }

        public async Task<Game> GetById(int id){
            return await context.Games.FindAsync(id);
        }

        public async Task Add(Game game){
            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}