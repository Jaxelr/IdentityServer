using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace IdentityServerAdmin.Models
{
    public class ApiScope
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Emphasize { get; set; }

        public bool Required { get; set; }

        [Display(Name = "Show In Discovery")]
        public bool ShowInDiscoveryDocument { get; set; }

        [Display(Name = "Api Resource Id")]
        public int ApiResourceId { get; set; }
    }

    public class ApiScopeValidator : AbstractValidator<ApiScope>
    {
        public ApiScopeValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, 9999);
            RuleFor(x => x.Name).Length(3, 200).NotEmpty();
            RuleFor(x => x.DisplayName).Length(3, 200);
            RuleFor(x => x.Description).Length(3, 2000);
        }
    }
}
