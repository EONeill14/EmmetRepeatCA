using EmmetRepeatCA.Models;
using EmmetRepeatCA.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmmetRepeatCA.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string? genre, int productPage = 1)
        {
            var viewModel = new ProductsListViewModel
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
                                 : repository.Vinyls.Count(v => v.Genre == genre)
                },
                CurrentGenre = genre 
            };

            return View(viewModel);
        }


    }
}
