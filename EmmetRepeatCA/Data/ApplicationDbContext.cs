using Microsoft.EntityFrameworkCore;
using EmmetRepeatCA.Models;  // Ensure this using directive is present

namespace EmmetRepeatCA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Vinyl> Vinyls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Vinyls)
                .WithOne(v => v.Artist)
                .HasForeignKey(v => v.ArtistId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
