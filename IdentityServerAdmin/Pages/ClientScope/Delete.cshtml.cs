using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using model = IdentityServerAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServerAdmin.Pages.ClientScope
{
    public class DeleteModel : PageModel
    {
        private readonly ClientRepository repository;

        public DeleteModel(ClientRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public model.ClientScope ClientScope { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await repository.GetClientScopes(id: id.GetValueOrDefault())
               .ConfigureAwait(false);

            ClientScope = response.FirstOrDefault();

            if (ClientScope == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _ = await repository.DeleteClientScope(id.GetValueOrDefault())
                .ConfigureAwait(false);

            return RedirectToPage("../Client/Details", new { Id = ClientScope.ClientId });
        }
    }
}
