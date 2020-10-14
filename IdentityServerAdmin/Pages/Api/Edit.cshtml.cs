using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.Api
{
    public class EditModel : PageModel
    {
        private readonly ApiRepository repository;

        public EditModel(ApiRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public model.Api Api { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resp = await repository.GetApiResources(id.GetValueOrDefault())
                .ConfigureAwait(false);

            Api = resp.FirstOrDefault();

            if (Api == null)
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

            var existing = await repository.GetApiResources(name: Api.Name).ConfigureAwait(false);

            if (existing.Any(x => x.Name == Api.Name && x.Id != Api.Id))
            {
                ModelState.AddModelError("DupeName", "This Api name already exists on the system.");
                return Page();
            }

            _ = await repository.StoreApiResource(Api)
                .ConfigureAwait(false);

            return RedirectToPage("./Index");
        }
    }
}
