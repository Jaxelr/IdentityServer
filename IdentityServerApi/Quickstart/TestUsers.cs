// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Test;

namespace IdentityServer4.Quickstart.UI
{
    public static class RootUser
    {
        internal static List<TestUser> Users = new()
        {
            new TestUser
            {
                SubjectId = "818727",
                Username = "jaxel",
                Password = "jaxel",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Jaxel Rojas"),
                    new Claim(JwtClaimTypes.GivenName, "Jaxel"),
                    new Claim(JwtClaimTypes.FamilyName, "Rojas"),
                    new Claim(JwtClaimTypes.Email, "jaxel@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://github.com/jaxelr")
                }
            }
        };
    }
}
