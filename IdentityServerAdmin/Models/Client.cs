using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace IdentityServerAdmin.Models
{
    public class Client
    {
        public int Id { get; set; }

        public bool Enabled { get; set; }

        [Display(Name = "Client Id")]
        public string ClientId { get; set; }

        [Display(Name = "Protocol Type")]
        public string ProtocolType { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Client Uri")]
        public string ClientUri { get; set; }

        [Display(Name = "Logo Uri")]
        public string LogoUri { get; set; }

        [Display(Name = "Front Channel Logout Uri")]
        public string FrontChannelLogoutUri { get; set; }

        [Display(Name = "Back Channel Logout Uri")]
        public string BackChannelLogoutUri { get; set; }

        [Display(Name = "Identity Token Lifetime")]
        public int IdentityTokenLifetime { get; set; }

        [Display(Name = "Authorization Code Lifetime")]
        public int AuthorizationCodeLifetime { get; set; }

        [Display(Name = "Consent Lifetime")]
        public int ConsentLifetime { get; set; }

        [Display(Name = "Access Token Lifetime")]
        public int AccessTokenLifetime { get; set; }

        [Display(Name = "User SSO Lifetime")]
        public int UserSsoLifetime { get; set; }

        [Display(Name = "User Code Type")]
        public string UserCodeType { get; set; }

        [Display(Name = "Allowed Identity Token Signing Algorithms")]
        public string AllowedIdentityTokenSigningAlgorithms { get; set; }

        [Display(Name = "Device Code Lifetime")]
        public int DeviceCodeLifetime { get; set; }

        public IEnumerable<ClientScope> Scopes { get; set; }
    }

    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, 9999);
            RuleFor(x => x.ClientId).Length(3, 200).NotEmpty();
            RuleFor(x => x.ProtocolType).Length(3, 200).NotEmpty();
            RuleFor(x => x.ClientName).Length(3, 200).NotEmpty();
            RuleFor(x => x.Description).Length(3, 200);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.LogoUri).Length(5, 2000);
            RuleFor(x => x.ClientUri).Length(5, 2000);
            RuleFor(x => x.FrontChannelLogoutUri).Length(5, 2000);
            RuleFor(x => x.BackChannelLogoutUri).Length(5, 2000);
            RuleFor(x => x.IdentityTokenLifetime).InclusiveBetween(300, 3600);
            RuleFor(x => x.AuthorizationCodeLifetime).InclusiveBetween(300, 3600);
            RuleFor(x => x.ConsentLifetime).InclusiveBetween(0, 3600);
            RuleFor(x => x.AccessTokenLifetime).InclusiveBetween(300, 3600);
            RuleFor(x => x.UserSsoLifetime).InclusiveBetween(300, 3600);
            RuleFor(x => x.DeviceCodeLifetime).InclusiveBetween(0, 3600);
        }
    }
}
