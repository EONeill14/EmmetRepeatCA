using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EmmetRepeatCA.Models
{
    public interface IStoreRepository
    {
        IQueryable<Vinyl> Vinyls { get; }

        void SaveVinyl(Vinyl v);
        void CreateVinyl(Vinyl v);
        void DeleteVinyl(Vinyl v);
        Task<List<Vinyl>> GetVinylsAsync();

    }
}
