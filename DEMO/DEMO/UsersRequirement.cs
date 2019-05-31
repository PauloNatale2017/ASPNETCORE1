using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO
{
    public class UsersRequirement : IAuthorizationRequirement //marker Interface
    {
        public UsersRequirement(string _User, string _Password)  {
            User = _User;
            Password = _Password;
        }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
