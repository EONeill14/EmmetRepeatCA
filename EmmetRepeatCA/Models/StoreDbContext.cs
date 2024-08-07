using Microsoft.EntityFrameworkCore;
using EmmetRepeatCA.Models;

namespace EmmetRepeatCA.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        public DbSet<Vinyl> Vinyls { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
