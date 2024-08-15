using Microsoft.AspNetCore.Mvc;
using EmmetRepeatCA.Models;
using System.Linq;

namespace EmmetRepeatCA.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["genre"];
            return View(repository.Vinyls
                .Select(x => x.Genre)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
