using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.Client
{
    public class CreateModel : PageModel
    {
        private readonly ClientRepository repository;

        public CreateModel(ClientRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet() => Page();

        [BindProperty]
        public Model.Client Client { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Client.Password = Client.Password.ToSha256();

            _ = await repository.StoreClient(Client)
                    .ConfigureAwait(false);

            return RedirectToPage("./Index");
        }
    }
}
