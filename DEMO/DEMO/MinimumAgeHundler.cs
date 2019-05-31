using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DEMO
{
    public class MinimumAgeHundler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            if(!context.User.HasClaim(c=>c.Type == ClaimTypes.DateOfBirth &&
                                         c.Issuer == "http://contoso.com"))
            {
                // MT 4.x -> return task.fromResult(0);
                return Task.CompletedTask;
            }

            var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(
                c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "http://contoso.com").Value);

            int calculateAge = DateTime.Today.Year - dateOfBirth.Year;
            if(dateOfBirth > DateTime.Today.AddYears(-calculateAge))
            {
                calculateAge--;
            }

            if(calculateAge >= requirement.MinimunAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
            //throw new NotImplementedException();
        }
    }
}
