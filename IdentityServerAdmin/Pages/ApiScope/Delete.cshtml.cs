using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Model = IdentityServerAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServerAdmin.Pages.ApiScope
{
    public class DeleteModel : PageModel
    {
        private readonly ApiRepository repository;

        public DeleteModel(ApiRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Model.ApiScope ApiScope { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _ = await repository.DeleteApiScope(id.GetValueOrDefault())
                .ConfigureAwait(false);

            return RedirectToPage("../Api/Details", new { Id = ApiScope.ApiResourceId });
        }
    }
}
