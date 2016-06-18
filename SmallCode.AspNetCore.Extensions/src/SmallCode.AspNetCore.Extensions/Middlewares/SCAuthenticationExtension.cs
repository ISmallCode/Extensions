using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode.AspNetCore.Extensions.Middlewares
{
    public static class SCAuthenticationExtension
    {
        public static IApplicationBuilder UseSCAuthentication(this IApplicationBuilder app, string RedirctUrl = "/Account/Login")
        {
            return app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString(RedirctUrl),
                AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme,
            });
        }
    }

}
