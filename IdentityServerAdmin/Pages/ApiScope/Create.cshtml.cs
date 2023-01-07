using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.ApiScope
{
    public class CreateModel : PageModel
    {
        private readonly ApiRepository repository;

        public CreateModel(ApiRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet(int? apiResourceId)
        {
            if (!apiResourceId.HasValue)
            {
                return RedirectToPage("../Api/Index");
            }

            return Page();
        }

        [BindProperty]
        public Model.ApiScope ApiScope { get; set; }

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
