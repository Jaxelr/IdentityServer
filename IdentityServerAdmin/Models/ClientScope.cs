using FluentValidation;

namespace IdentityServerAdmin.Models
{
    public class ClientScope
    {
        public int Id { get; set; }

        public string Scope { get; set; }

        public int ClientId { get; set; }
    }

    public class ClientScopeValidator : AbstractValidator<ClientScope>
    {
        public ClientScopeValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, 9999);
            RuleFor(x => x.Scope).Length(3, 200).NotEmpty();
            RuleFor(x => x.ClientId).InclusiveBetween(1, 9999).NotEmpty();
        }
    }
}
