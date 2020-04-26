using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using werwolfonline.Database.Model;
using werwolfonline.Models.Enums;

namespace werwolfonline.Database
{
    public class WerewolfContext : DbContext
    {
        private readonly string connectionString = "";

        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;

        public WerewolfContext() { }
        public WerewolfContext(DbContextOptions<WerewolfContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(game => game.Phase)
                .HasConversion(new EnumToStringConverter<Phase>());

            modelBuilder.Entity<Game>()
                .HasOne(game => game.WerewolfVictim);

            modelBuilder.Entity<Player>()
                .HasOne(player => player.Game)
                .WithMany(game => game.Players);

            modelBuilder.Entity<Player>()
                .HasOne(player => player.VoteFor)
                .WithMany(player => player!.Voters);

            modelBuilder.Entity<Player>()
                .HasOne(player => player.Associate);

            modelBuilder.Entity<Player>()
                .HasOne(player => player.Lover);

            modelBuilder.Entity<Player>()
                .HasOne(player => player.LastAssociate);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseMySql(connectionString);
            }
        }
    }
}