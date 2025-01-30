using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Why.Data;
using Why.Data.Models;
using Why.ModelsServices;
using Why.Repositories;
using Why;

namespace Why.Controllers
{
    public class AdminController : Controller
    {
        ThumbManager tm = new ThumbManager(new ThumbRepository());
        BiographyManager bm = new BiographyManager(new BiographyRepository());
        UserManager um = new UserManager(new UserRepository());
        Thumb thumbsId = new Thumb();

        



        [Authorize]
        public IActionResult Index()
        {
            List<Thumb> thumbid = new List<Thumb>();
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;

            var thumbList = tm.GetList();

            foreach (var item in thumbList)
            {
                if (item.UsersName == User.Identity.Name)
                {

                    thumbid.Add(item);
                }


            }



            if (thumbid == null)
            {
                return View();
            }
            else
            {
                return View(thumbid);
            }

        }
        public IActionResult Create()
        {
            return RedirectToAction("Thumb", "Admin");
        }
        [HttpGet]
        public IActionResult Thumb(string name)
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;

            if (name == "Bronze")
            {
                ViewBag.thumbClassName = name;
            }
            else if (name == "Silver")
            {
                ViewBag.thumbClassName = name;
            }
            else if (name == "Gold")
            {
                ViewBag.thumbClassName = name;
            }

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Thumb(Thumb t)
        {


            t.UsersName = User.Identity.Name;

            tm.ThumbAdd(t);

            await Task.CompletedTask;
            return RedirectToAction("Biography", "Admin");
        }
        [HttpGet]
        public IActionResult Thumbdel(int id)
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;
            var delThumb = tm.GetbyId(id);
            var delBio = bm.GetbyId(id);
            tm.ThumbRemove(delThumb);
            bm.BiographyRemove(delBio);
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public IActionResult ThumbEdit(int id)
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;
            var delThumb = tm.GetbyId(id);

            return View(delThumb);
        }
        [HttpPost]
        public IActionResult ThumbEdit(Thumb thumb)
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;

            var wenThumb = tm.GetbyId(thumb.ThumbId);
            if (thumb.ThumbName != null)
            {
                wenThumb.ThumbName = thumb.ThumbName;
            }
            if (thumb.ThumbLastName != null)
            {
                wenThumb.ThumbLastName = thumb.ThumbLastName;
            }
            if (thumb.ThumbTag != null)
            {
                wenThumb.ThumbTag = thumb.ThumbTag;
            }
            if (thumb.ThumbBiography != null)
            {
                wenThumb.ThumbBiography = thumb.ThumbBiography;
            }
            if (thumb.Date != null)
            {
                wenThumb.Date = thumb.Date;
            }
            if (thumb.ThumbClass != null)
            {
                wenThumb.ThumbClass = thumb.ThumbClass;
            }


            if (wenThumb.UsersName != null)
            {
                tm.ThumbUpdate(wenThumb);
                var idd = wenThumb.ThumbId;
                return RedirectToAction("BiographyEdit", "Admin", new { id = idd });

            }
            else
            {
                return View();
            }


        }





        public IActionResult Biography()
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Biography(Biography b)
        {
            if (b.BiographyContent == null)
            {
                List<Thumb> thumbsList = new List<Thumb>();
                b.BiographyContent = "Null";
                var thumbList = tm.GetList();

                foreach (var item in thumbList)
                {
                    if (item.UsersName == User.Identity.Name)
                    {
                        thumbsList.Add(item);


                    }
                }
                b.ThumbsId = thumbsList.Last().ThumbId;
                bm.BiographyAdd(b);
            }
            else
            {
                List<Thumb> thumbsList = new List<Thumb>();
                var thumbList = tm.GetList();

                foreach (var item in thumbList)
                {
                    if (item.UsersName == User.Identity.Name)
                    {
                        thumbsList.Add(item);
                    }
                }
                b.ThumbsId = thumbsList.Last().ThumbId;
                bm.BiographyAdd(b);
            }

            await Task.CompletedTask;
            return RedirectToAction("Index", "Admin");
        }


        [HttpGet]
        public IActionResult BiographyEdit(int id)
        {

            
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;

            foreach (var item in bm.GetList())
            {
                if (item.ThumbsId == id)
                {
                    var wenBio = item;
                    
                    return View(wenBio);
                }
            }

            
            return View();
        }

        [HttpPost]
        public IActionResult BiographyEdit(Biography bio)
        {

            foreach (var item in bm.GetList())
            {
                if (item.ThumbsId == bio.ThumbsId)
                {
                    var wenBio = item;
                    
                    wenBio.BiographyContent = bio.BiographyContent;
                    

                    bm.BiographyUpdate(wenBio);
                    return RedirectToAction("Index", "Admin");
                }
                
            }


            return View();



        }
        [AllowAnonymous]
        public IActionResult Info(int id)
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;
            var userValue = um.GetList();

            var thumbid = tm.GetbyId(id);



            foreach (var item in userValue)
            {
                if (item.UserEmail == userClaim)
                {
                    ViewBag.userMainName = item.UserName;
                }
                if (item.UserEmail == thumbid.UsersName)
                {
                    ViewBag.userName = item.UserName;
                    ViewBag.userLast = item.UserLastName;
                    string userMail = item.UserEmail;
                    ViewBag.userMail = userMail;
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult Market()
        {
            return View();
        }




    }
}
