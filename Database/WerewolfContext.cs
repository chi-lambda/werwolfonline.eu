using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using werwolfonline.Database.Model;
using werwolfonline.Models.Enums;

namespace werwolfonline.Database
{
    public class WerewolfContext : DbContext
    {
        public DbSet<Player> Players { get; }
        public DbSet<Game> Games { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Game>()
                .Property(game => game.Phase)
                .HasConversion(new EnumToStringConverter<Phase>());

            modelBuilder.Entity<Player>()
                .Property(player => player.VerificationNumber)
                .HasConversion(new GuidToStringConverter());
        }
    }
}