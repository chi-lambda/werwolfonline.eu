using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using werwolfonline.Database.Model;
using Xunit;

namespace werwolfonline.Database.Repositories.Test
{
    public class GameRepository_Test
    {
        [Fact]
        public async Task Add_Game_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Add_Game_Test_database")
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var repo = new GameRepository(context);
                await repo.Add(new Game());
            }

            using (var context = new WerewolfContext(options))
            {
                var repo = new GameRepository(context);
                Assert.Equal(1, await repo.Count());
            }
        }

        public async Task Add_Game_With_Players_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Add_Game_With_Players_database")
                .UseLazyLoadingProxies()
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context);
                var playerRepo = new PlayerRepository(context);
                var game = new Game();
                await gameRepo.Add(game);
                await playerRepo.Add(new Player() { Game = game });
                await playerRepo.Add(new Player() { Game = game });
            }

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context);
                var playerRepo = new PlayerRepository(context);
                var game = await gameRepo.GetById(1);
                Assert.Equal(1, await gameRepo.Count());
                Assert.Equal(2, await playerRepo.Count());
                Assert.Equal(2, game.Players.Count);
            }
        }
    }
}