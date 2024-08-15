using Microsoft.AspNetCore.Mvc;
using EmmetRepeatCA.Models;
using EmmetRepeatCA.Models.ViewModels;

namespace EmmetRepeatCA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository repository;
        private const int PageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string? genre, int productPage = 1)
           => View(new ProductsListViewModel
           {
               Vinyls = repository.Vinyls
                    .Where(v => genre == null || v.Genre == genre)
                   .OrderBy(v => v.VinylId)
                   .Skip((productPage - 1) * PageSize)
                   .Take(PageSize),
               PagingInfo = new PagingInfo
               {
                   CurrentPage = productPage,
                   ItemsPerPage = PageSize,
                   TotalItems = genre == null
                        ? repository.Vinyls.Count()
                        : repository.Vinyls.Where(v => v.Genre == genre).Count()
               },
               CurrentGenre = genre
           });


    }
}
