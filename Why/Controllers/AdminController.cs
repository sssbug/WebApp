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
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;

namespace Why.Controllers
{
    public class AdminController : Controller
    {
        ThumbManager tm = new ThumbManager(new ThumbRepository());
        BiographyManager bm = new BiographyManager(new BiographyRepository());
        UserManager um = new UserManager(new UserRepository());
        Thumb thumbsId = new Thumb();
        CategoryManager cm = new CategoryManager(new CategoryRepository());




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

            

            return View(cm.GetList());
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
        public async Task<IActionResult> Biography(Biography b, List<IFormFile> imageFiles)
        {
            if (string.IsNullOrEmpty(b.BiographyContent))
            {
                b.BiographyContent = "Null";
            }

            List<Thumb> thumbsList = tm.GetList()
                                       .Where(item => item.UsersName == User.Identity.Name)
                                       .ToList();
            if (thumbsList.Any())
            {
                b.ThumbsId = thumbsList.Last().ThumbId;
            }

            // Resim dosyalarını base64 formatında depola
            if (imageFiles != null && imageFiles.Count > 0)
            {
                List<string> imagesDataList = new List<string>();

                foreach (var imageFile in imageFiles)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await imageFile.CopyToAsync(memoryStream);
                        var imageBase64 = Convert.ToBase64String(memoryStream.ToArray());
                        imagesDataList.Add(imageBase64);
                    }
                }

                b.ImageDataList = string.Join(",", imagesDataList); // Base64 stringlerini virgülle birleştir
            }

            bm.BiographyAdd(b); // Veritabanına kaydet

            return RedirectToAction("Index", "Admin"); // Yönlendirme
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
