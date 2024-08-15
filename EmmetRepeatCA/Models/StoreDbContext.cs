using Microsoft.EntityFrameworkCore;

namespace EmmetRepeatCA.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        public DbSet<Vinyl> Vinyls => Set<Vinyl>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Artist> Artists => Set<Artist>();

    }
}
