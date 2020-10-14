using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace IdentityServerAdmin.Models
{
    public class Api
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        [Display(Name = "Read Only")]
        public bool NonEditable { get; set; }

        public IEnumerable<ApiScope> Scopes { get; set; }
    }

    public class ApiValidator : AbstractValidator<Api>
    {
        public ApiValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, 9999);
            RuleFor(x => x.Name).Length(3, 200).NotEmpty();
            RuleFor(x => x.DisplayName).Length(3, 200);
            RuleFor(x => x.Description).Length(3, 2000);
        }
    }
}
