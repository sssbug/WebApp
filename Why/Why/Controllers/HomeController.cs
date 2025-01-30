using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using Why.AbstractServices;
using Why.Data.Models;
using Why.Models;
using Why.ModelsServices;
using Why.Repositories;


namespace Why.Controllers
{
    public class HomeController : Controller
    {
        


        ThumbManager tm = new ThumbManager(new ThumbRepository());
        BiographyManager bm = new BiographyManager(new BiographyRepository());
        UserManager um = new UserManager(new UserRepository());
        List<Thumb> thumbList = new List<Thumb>();

        [AllowAnonymous]
        public IActionResult Index(string name)
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;
            if (name == null)
            {
                var values = tm.GetList();
                return View(values);
            }
            else
            {
                var values = tm.GetList();
                foreach (var item in values)
                {
                    if (item.ThumbTag == name)
                    {
                        thumbList.Add(item);
                    }
                    

                }
                if (thumbList == null)
                {
                    return View();
                }
                else
                {
                    return View(thumbList);

                }

            }
            
            
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;

            var userValue = um.GetList();
            var userid = um.GetbyId(id);
            var thumbid = tm.GetbyId(id);

            ViewBag.thumbId = thumbid.ThumbId;

            foreach (var item in userValue)
            {
                if (item.UserEmail == thumbid.UsersName)
                {
                    ViewBag.userName = item.UserName;
                }
            }




            var value = bm.GetList();
            
            if (value != null)
            {
                Biography bioId = null;
                foreach (var item in value)
                {
                    if (item.ThumbsId == id)
                    {
                        bioId = item;
                    }
                }
                var bio = bioId;
                if (bio != null)
                {
                    var model = new Biography()
                    {
                        BiographyId = bio.ThumbsId,
                        BiographyContent = bio.BiographyContent,
                        BiographyTitle = bio.BiographyTitle,
                        BiographyUserName = bio.BiographyUserName,
                        


                    };
                    return View(model);
                }
                else
                {
                    var model = new Biography()
                    {
                        BiographyContent = "NUll"
                    };

                    return View(model);
                }
            }
            else {
                var model = new Biography()
                {
                    BiographyContent = "NUll"
                };
                return View(model);
            }

            
            
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}