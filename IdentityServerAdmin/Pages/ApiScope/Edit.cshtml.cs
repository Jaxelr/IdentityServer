using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.ApiScope
{
    public class EditModel : PageModel
    {
        private readonly ApiRepository repository;

        public EditModel(ApiRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existing = await repository.GetApiScopes(name: ApiScope.Name)
                .ConfigureAwait(false);

            if (existing.Any(x => x.Name == ApiScope.Name && x.Id != ApiScope.Id))
            {
                ModelState.AddModelError("DupeName", "This Api Scope name already exists on the system");
                return Page();
            }

            _ = await repository.StoreApiScope(ApiScope)
                .ConfigureAwait(false);

            return RedirectToPage("../Api/Details", new { id = ApiScope.ApiResourceId });
        }
    }
}
