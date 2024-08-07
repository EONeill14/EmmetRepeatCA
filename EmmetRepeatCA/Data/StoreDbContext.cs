using Microsoft.EntityFrameworkCore;
using EmmetRepeatCA.Models;

namespace EmmetRepeatCA.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Vinyl> Vinyls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vinyl>()
                .Property(v => v.Price)
                .HasPrecision(18, 2);  // Specify precision and scale here

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Vinyls)
                .WithOne(v => v.Artist)
                .HasForeignKey(v => v.ArtistId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
