using System.Linq;
using System.Threading.Tasks;
using model = IdentityServerAdmin.Models;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServerAdmin.Pages.ApiScope
{
    public class DetailsModel : PageModel
    {
        private readonly ApiRepository repository;

        public DetailsModel(ApiRepository repository)
        {
            this.repository = repository;
        }

        public model.ApiScope ApiScope { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await repository.GetApiScopes(id: id.GetValueOrDefault())
                .ConfigureAwait(false);

            ApiScope = response.FirstOrDefault();

            if (ApiScope == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
