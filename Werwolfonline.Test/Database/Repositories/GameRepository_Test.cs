using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using werwolfonline.Database.Model;
using werwolfonline.Database.Model.Enums;
using werwolfonline.Utils;
using Xunit;

namespace werwolfonline.Database.Repositories.Test
{
    public class GameRepository_Test
    {
        private readonly CorrectHorseBatteryStaple chbs = new CorrectHorseBatteryStaple();

        [Fact]
        public async Task Add_Game_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Add_Game_Test_database")
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var repo = new GameRepository(context, chbs);
                await repo.Add(new Game());
            }

            using (var context = new WerewolfContext(options))
            {
                var repo = new GameRepository(context, chbs);
                Assert.Equal(1, await repo.Count());
            }
        }

        [Fact]
        public async Task Add_Game_With_Players_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Add_Game_With_Players_database")
                .UseLazyLoadingProxies()
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context, chbs);
                var playerRepo = new PlayerRepository(context);
                var game = new Game();
                await gameRepo.Add(game);
                await playerRepo.Add(new Player() { Game = game });
                await playerRepo.Add(new Player() { Game = game });
            }

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context, chbs);
                var playerRepo = new PlayerRepository(context);
                var game = await gameRepo.GetById(1);
                Assert.Equal(1, await gameRepo.Count());
                Assert.Equal(2, await playerRepo.Count());
                Assert.Equal(2, game.Players.Count);
            }
        }

        [Fact]
        public async Task Set_Phase_Without_Amor_and_Seer_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Set_Phase_Without_Amor_and_Seer_database")
                .UseLazyLoadingProxies()
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context, chbs);
                var playerRepo = new PlayerRepository(context);
                var game = new Game();
                await gameRepo.Add(game);
                await playerRepo.Add(new Player() { Game = game, Character = Character.Werewolf });
                await gameRepo.SetPhase(game, Phase.NightAmor);
                Assert.Equal(Phase.NightWolves, game.Phase);
            }
        }

        [Fact]
        public async Task Set_Phase_With_Amor_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Set_Phase_With_Amor_database")
                .UseLazyLoadingProxies()
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context, chbs);
                var playerRepo = new PlayerRepository(context);
                var game = new Game();
                await gameRepo.Add(game);
                await playerRepo.Add(new Player() { Game = game, Character = Character.Werewolf });
                await playerRepo.Add(new Player() { Game = game, Character = Character.Amor });
                await gameRepo.SetPhase(game, Phase.NightAmor);
                Assert.Equal(Phase.NightAmor, game.Phase);
            }
        }

        [Fact]
        public async Task Set_Phase_With_Amor_Second_Night_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Set_Phase_With_Amor_Second_Night_database")
                .UseLazyLoadingProxies()
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context, chbs);
                var playerRepo = new PlayerRepository(context);
                var game = new Game() { Night = 1 };
                await gameRepo.Add(game);
                await playerRepo.Add(new Player() { Game = game, Character = Character.Werewolf });
                await playerRepo.Add(new Player() { Game = game, Character = Character.Amor });
                await gameRepo.SetPhase(game, Phase.NightAmor);
                Assert.Equal(Phase.NightWolves, game.Phase);
            }
        }

        [Fact]
        public async Task Set_Phase_With_Amor_and_Seer_Second_Night_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Set_Phase_With_Amor_and_Seer_Second_Night_database")
                .UseLazyLoadingProxies()
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context, chbs);
                var playerRepo = new PlayerRepository(context);
                var game = new Game() { Night = 1 };
                await gameRepo.Add(game);
                await playerRepo.Add(new Player() { Game = game, Character = Character.Werewolf });
                await playerRepo.Add(new Player() { Game = game, Character = Character.Amor });
                await playerRepo.Add(new Player() { Game = game, Character = Character.Seer });
                await gameRepo.SetPhase(game, Phase.NightAmor);
                Assert.Equal(Phase.NightSeer, game.Phase);
            }
        }

        [Fact]
        public async Task Set_Phase_Without_Amor_with_Seer_Test()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Set_Phase_Without_Amor_with_Seer_database")
                .UseLazyLoadingProxies()
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var gameRepo = new GameRepository(context, chbs);
                var playerRepo = new PlayerRepository(context);
                var game = new Game();
                await gameRepo.Add(game);
                await playerRepo.Add(new Player() { Game = game, Character = Character.Werewolf });
                await playerRepo.Add(new Player() { Game = game, Character = Character.Seer });
                await gameRepo.SetPhase(game, Phase.NightAmor);
                Assert.Equal(Phase.NightSeer, game.Phase);
            }
        }
    }
}