using Microsoft.AspNetCore.Mvc;
using Why.Data.Models;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Why.Repositories;
using Microsoft.AspNetCore.Identity;
using Why.ModelsServices;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Why.Data;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
namespace Why.Controllers
{
    public class AccountController : Controller
    {
        UserManager um = new UserManager(new UserRepository());
        int i;
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(User u)
        {

            var value = um.GetList();
            User dataValue = null;
            foreach (var item in value)
            {
                if (item.UserEmail != u.UserEmail)
                {
                    i++;

                    if (i == value.Count())
                    {
                        um.UseAdd(u);
                        WhyDbContext c = new WhyDbContext();

                        dataValue = c.Users.FirstOrDefault(x => x.UserEmail == u.UserEmail && x.UserPassword == u.UserPassword);
                        
                    }
                }
                else
                {
                    i = 0;
                    TempData["AllertMessage"] = "That Email is taken. Try another";
                    return View();
                }
            }

            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                  new Claim(ClaimTypes.Name,u.UserEmail)
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


    }
}
