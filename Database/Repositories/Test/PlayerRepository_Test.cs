using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using werwolfonline.Database.Model;
using Xunit;

namespace werwolfonline.Database.Repositories.Test
{
    public class PlayerRepository_Test
    {
        [Fact]
        public async Task Test1()
        {
            var options = new DbContextOptionsBuilder<WerewolfContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            using (var context = new WerewolfContext(options))
            {
                var repo = new PlayerRepository(context);
                await repo.Add(new Player("Name1", "connectionId1"));
            }

            using (var context = new WerewolfContext(options))
            {
                var repo = new PlayerRepository(context);
                Assert.Equal(1, await repo.Count());
            }
        }
    }
}