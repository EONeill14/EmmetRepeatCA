using System.Linq;

namespace EmmetRepeatCA.Models
{
    public interface IStoreRepository
    {
        IQueryable<Vinyl> Vinyls { get; }
    }
}
