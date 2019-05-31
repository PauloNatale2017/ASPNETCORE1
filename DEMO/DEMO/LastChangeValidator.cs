using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO
{
    public static class LastChangeValidator
    {
        public static async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            // pull database from registered DI Services
            //var userRepository = context.HttpContext.RequestServices
            //    .GetRequiredService<IUserRepository>();

            var userPrincipal = context.Principal;

            //look for the last changed claim
            string lastChanged;
            lastChanged = (from c in userPrincipal.Claims
                           where c.Type == "LastUpdate"
                           select c.Value).FirstOrDefault();

            if (string.IsNullOrEmpty(lastChanged))
            {
                context.RejectPrincipal();
                await context.HttpContext.Authentication.SignOutAsync("Cookies");
            }

        }
    }
}
