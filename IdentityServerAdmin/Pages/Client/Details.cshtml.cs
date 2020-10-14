using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.Client
{
    public class DetailsModel : PageModel
    {
        private readonly ClientRepository repository;

        public DetailsModel(ClientRepository repository)
        {
            this.repository = repository;
        }

        public model.Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientTask = repository.GetClients(id.GetValueOrDefault());

            var clientScopeTask = repository.GetClientScopes(clientId: id.GetValueOrDefault());

            await Task.WhenAll(clientTask, clientScopeTask)
                .ConfigureAwait(false);

            Client = clientTask.Result.FirstOrDefault();

            if (Client == null)
            {
                return NotFound();
            }

            Client.Scopes = clientScopeTask.Result;

            return Page();
        }
    }
}
