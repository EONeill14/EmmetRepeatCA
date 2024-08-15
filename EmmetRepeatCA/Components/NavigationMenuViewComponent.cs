using Microsoft.AspNetCore.Mvc;
using EmmetRepeatCA.Models;
using System.Linq;

namespace EmmetRepeatCA.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            var genres = repository.Vinyls
                                   .Select(v => v.Genre)
                                   .Distinct()
                                   .OrderBy(genre => genre)
                                   .ToList();

            return View(genres);
        }
    }
}
