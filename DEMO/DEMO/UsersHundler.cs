using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DEMO
{
    public class UsersHundler : AuthorizationHandler<UsersRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UsersRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth &&
                                          c.Issuer == "http://contoso.com"))
            {
                // MT 4.x -> return task.fromResult(0);
                return Task.CompletedTask;
            }
            var UserName = context.User.FindFirst(c => c.Type == ClaimTypes.Name).Value;

            if(string.IsNullOrEmpty(UserName))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}
