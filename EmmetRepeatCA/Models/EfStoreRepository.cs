using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmmetRepeatCA.Models
{
    public class EfStoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _context;

        public EfStoreRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Vinyl> Vinyls => _context.Vinyls;

        public async Task<List<Vinyl>> GetVinylsAsync()
        {
            return await _context.Vinyls.ToListAsync();
        }

        public void SaveVinyl(Vinyl v)
        {
            _context.Vinyls.Update(v);
            _context.SaveChanges();
        }

        public void CreateVinyl(Vinyl v)
        {
            _context.Vinyls.Add(v);
            _context.SaveChanges();
        }

        public void DeleteVinyl(Vinyl v)
        {
            _context.Vinyls.Remove(v);
            _context.SaveChanges();
        }
    }
}
