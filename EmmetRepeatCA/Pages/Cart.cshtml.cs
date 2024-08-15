using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmmetRepeatCA.Infrastructure;
using EmmetRepeatCA.Models;

namespace EmmetRepeatCA.Pages
{

    public class CartModel : PageModel
    {
        private IStoreRepository repository;

        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long vinylId, string returnUrl)
        {
            Vinyl? vinyl = repository.Vinyls
                .FirstOrDefault(v => v.VinylId == vinylId);
            if (vinyl != null)
            {
                Cart.AddItem(vinyl, 1);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long vinylId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Vinyl.VinylId == vinylId).Vinyl);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
