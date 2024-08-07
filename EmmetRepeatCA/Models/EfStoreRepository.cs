using EmmetRepeatCA.Data;
using EmmetRepeatCA.Models;
using Microsoft.EntityFrameworkCore;  // Add this using directive

namespace EmmetRepeatCA.Models
{
    public class EfStoreRepository : IStoreRepository
    {
        private StoreDbContext context;

        public EfStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Vinyl> Vinyls => context.Vinyls.Include(v => v.Artist);
    }
}
