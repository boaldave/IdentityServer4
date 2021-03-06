﻿using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace IdentityServer4.Configuration
{
    public class ConfigureInternalCookieOptions : ConfigureNamedOptions<CookieAuthenticationOptions>
    {
        private readonly IdentityServerOptions _idsrv;

        public ConfigureInternalCookieOptions(IdentityServerOptions idsrv)
            :base(IdentityServerConstants.DefaultCookieAuthenticationScheme, null)
        {
            _idsrv = idsrv;
        }

        public override void Configure(string name, CookieAuthenticationOptions options)
        {
            if (name == IdentityServerConstants.DefaultCookieAuthenticationScheme)
            {
                options.SlidingExpiration = _idsrv.Authentication.CookieSlidingExpiration;
                options.ExpireTimeSpan = _idsrv.Authentication.CookieLifetime;
                options.CookieName = IdentityServerConstants.DefaultCookieAuthenticationScheme;
                options.LoginPath = ExtractLocalUrl(_idsrv.UserInteraction.LoginUrl);
                options.LogoutPath = ExtractLocalUrl(_idsrv.UserInteraction.LogoutUrl);
                options.ReturnUrlParameter = _idsrv.UserInteraction.LoginReturnUrlParameter;
            }
        }

        private static string ExtractLocalUrl(string url)
        {
            if (url.IsLocalUrl())
            {
                if (url.StartsWith("~/"))
                {
                    url = url.Substring(1);
                }

                return url;
            }

            return null;
        }
    }

}
