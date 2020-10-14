using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.Api
{
    public class IndexModel : PageModel
    {
        private readonly ApiRepository repository;

        public IndexModel(ApiRepository repository)
        {
            this.repository = repository;
        }

        public IList<model.Api> Api { get; set; }

        public async Task OnGetAsync() =>
            Api = await repository.GetApiResources()
            .ConfigureAwait(false);
    }
}
