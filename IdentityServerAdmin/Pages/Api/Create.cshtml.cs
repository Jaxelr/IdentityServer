using System.Linq;
using System.Threading.Tasks;
using IdentityServerAdmin.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model = IdentityServerAdmin.Models;

namespace IdentityServerAdmin.Pages.Api
{
    public class CreateModel : PageModel
    {
        private readonly ApiRepository repository;

        public CreateModel(ApiRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet() => Page();

        [BindProperty]
        public Model.Api Api { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existing = await repository.GetApiResources(name: Api.Name)
                .ConfigureAwait(false);

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
