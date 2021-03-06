using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using werwolfonline.Database.Model;
using werwolfonline.Database.Model.Enums;

namespace werwolfonline.Database
{
    public class WerewolfContext : DbContext
    {
        private readonly string connectionString = "";

        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<CharacterCount> CharacterCounts { get; set; } = null!;

        public WerewolfContext() { }
        public WerewolfContext(DbContextOptions<WerewolfContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(game => game.Phase)
                .HasConversion(new EnumToStringConverter<Phase>());

            modelBuilder.Entity<Game>()
                .HasOne(game => game.WerewolfVictim);

            modelBuilder.Entity<CharacterCount>()
                .HasOne(cc => cc.Game)
                .WithMany(game => game.CharacterCounts);

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

            modelBuilder.Entity<Player>()
                .HasIndex(player => player.ConnectionId);
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