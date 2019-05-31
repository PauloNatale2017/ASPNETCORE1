using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEMO.Controllers
{
    [Authorize(Policy = "Over21")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AutoLogin()
        {
            var Claims = new List<Claim>() // padrão de mercado
            {
                 new Claim(ClaimTypes.Name,"PAULO"),
                 new Claim(ClaimTypes.Surname,"ROBERTO"),
                 new Claim(ClaimTypes.Surname,"NATALE"),
                 new Claim("NF","EMITIR")
            };
            var Identity = new ClaimsIdentity(Claims); // Identidade do usuario
            var principal = new ClaimsPrincipal(Identity); //contexto de segurança
            HttpContext.Authentication.SignInAsync("Cookies", principal);
            return RedirectToAction("Index", "Home");
        }
    }
}
