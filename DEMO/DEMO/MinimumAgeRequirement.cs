using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO
{
    public class MinimumAgeRequirement : IAuthorizationRequirement //marker Interface
    {
        public MinimumAgeRequirement(int Age)
        {
            MinimunAge = Age;
        }
        public int MinimunAge { get; set; }
    }
}
