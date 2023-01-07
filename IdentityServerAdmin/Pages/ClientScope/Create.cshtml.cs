using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model = IdentityServerAdmin.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServerAdmin.Pages.ClientScope
{
    public class CreateModel : PageModel
    {
        private readonly ClientRepository repository;

        public CreateModel(ClientRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet(int? clientId)
        {
            if (!clientId.HasValue)
            {
                return RedirectToPage("../Client/Index");
            }

            return  Page();
        }
        [BindProperty]
        public Model.ClientScope ClientScope { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ = await repository.StoreClientScope(ClientScope)
                .ConfigureAwait(false);

            return RedirectToPage("../Client/Details", new { id = ClientScope.ClientId });
        }
    }
}
