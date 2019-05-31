using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO
{
    public class UsersAuthorizationHandler : AuthorizationHandler<UsersRequirement, LoginUsers>
    {
        //public override Task HandleRequirementAsync (AuthorizationHandlerContext context,
        //    UsersRequirement requirement,
        //    LoginUsers resource)
        //{
        //    return Task.CompletedTask;
        //}
    }
}
