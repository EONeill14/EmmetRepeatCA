using System.Linq;
using EmmetRepeatCA.Data; // Add this using directive

namespace EmmetRepeatCA.Models
{
    public class EfStoreRepository : IStoreRepository
    {
        private StoreDbContext context;

        public EfStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Vinyl> Vinyls => context.Vinyls;
    }
}
