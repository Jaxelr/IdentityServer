using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.Client
{
    public class IndexModel : PageModel
    {
        private readonly ClientRepository repository;

        public IndexModel(ClientRepository repository)
        {
            this.repository = repository;
        }

        public IList<model.Client> Client { get; set; }

        public async Task OnGetAsync() =>
            Client = await repository.GetClients()
            .ConfigureAwait(false);
    }
}
