using EmmetRepeatCA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmmetRepeatCA.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;

        public HomeController(IStoreRepository repos)
        {
            repository = repos;
        }

        public IActionResult Index() => View(repository.Vinyls);
    }
}
