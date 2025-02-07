using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Why.Data;
using Why.Data.Models;

namespace Why.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(User u)
        {
            WhyDbContext c = new WhyDbContext();
            var dataValue = c.Users.FirstOrDefault(x => x.UserEmail == u.UserEmail && x.UserPassword == u.UserPassword);
            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,u.UserEmail),
                    
                };

                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);


                return RedirectToAction("Index", "Admin");
            }
            else
            {        
                return View();
            }

        }

        public async Task<IActionResult> Logout(User u)
        {

            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
