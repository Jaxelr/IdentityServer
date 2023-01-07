using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.Client
{
    public class EditModel : PageModel
    {
        private readonly ClientRepository repository;

        public EditModel(ClientRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Model.Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await repository.GetClients(id.GetValueOrDefault())
                    .ConfigureAwait(false);

            Client = response.FirstOrDefault();

            if (Client == default)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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
