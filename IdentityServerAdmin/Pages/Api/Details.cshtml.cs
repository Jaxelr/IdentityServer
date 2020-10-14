using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.Api
{
    public class DetailsModel : PageModel
    {
        private readonly ApiRepository repository;

        public DetailsModel(ApiRepository repository)
        {
            this.repository = repository;
        }

        public model.Api Api { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiTask = repository.GetApiResources(id.GetValueOrDefault());
            var apiScopeTask = repository.GetApiScopes(apiResourceId: id.GetValueOrDefault());

            await Task.WhenAll(apiTask, apiScopeTask)
                .ConfigureAwait(false);

            Api = apiTask.Result.FirstOrDefault();

            if (Api == null)
            {
                return NotFound();
            }

            Api.Scopes = apiScopeTask.Result;

            return Page();
        }
    }
}
