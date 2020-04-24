using Microsoft.EntityFrameworkCore;
using werwolfonline.Database.Model;

namespace werwolfonline.Database
{
    public class WerewolfContext : DbContext
    {
        public DbSet<Player> Players { get; }
        public DbSet<Game> Games { get; }
    }
}