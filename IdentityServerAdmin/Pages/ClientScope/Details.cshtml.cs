using System.Linq;
using System.Threading.Tasks;
using model = IdentityServerAdmin.Models;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServerAdmin.Pages.ClientScope
{
    public class DetailsModel : PageModel
    {
        private readonly ClientRepository repository;

        public DetailsModel(ClientRepository repository)
        {
            this.repository = repository;
        }

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
    }
}
