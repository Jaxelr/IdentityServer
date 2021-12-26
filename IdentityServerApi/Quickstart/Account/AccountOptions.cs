// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace IdentityServer4.Quickstart.UI
{
    public static class AccountOptions
    {
        internal static bool AllowLocalLogin = true;
        internal static bool AllowRememberLogin = true;
        internal static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);

        internal static bool ShowLogoutPrompt = true;
        internal static bool AutomaticRedirectAfterSignOut = false;

        // specify the Windows authentication scheme being used
        public static readonly string WindowsAuthenticationSchemeName = Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme;

        // if user uses windows auth, should we load the groups from windows
        internal static bool IncludeWindowsGroups = false;

        internal static string InvalidCredentialsErrorMessage = "Invalid username or password";
    }
}
