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
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace Why.Controllers
{
    public class ChatController : Controller
    {
       
        ThumbManager tm = new ThumbManager(new ThumbRepository());
        BiographyManager bm = new BiographyManager(new BiographyRepository());
        UserManager um = new UserManager(new UserRepository());
        ChatManager cm = new ChatManager(new ChatRepository());
        ChatMessageManager cmm = new ChatMessageManager(new ChatMessageRepository());
        Thumb thumbsId = new Thumb();


        [Authorize]
        public IActionResult Index(string userEmail)
        {
            var userClaim = User.Identity.Name;
            ViewBag.userCount = userClaim;
            var userMail = um.GetList();
            Chat c = new Chat();

            foreach (var item in userMail)
            {
                if (item.UserEmail == User.Identity.Name)
                {
                    ViewBag.UserIdentity = item.UserName;
                    c.ChatFirstUserName = item.UserEmail.ToString();
                    
                }
            }
            if (userEmail == null)
            {
                c.ChatSecondUserName = "Null";
            }
            else
            {
                c.ChatSecondUserName = userEmail.ToString();
                ViewBag.chatSecondUsers = userEmail.ToString();
            }


            string chatUsersName = c.ChatFirstUserName + c.ChatSecondUserName;
            c.ChatUsersName = chatUsersName;


            WhyDbContext s = new WhyDbContext();
            var dataValue = s.Chats.FirstOrDefault(x => x.ChatUsersName == c.ChatUsersName);
            if (dataValue != null)
            {

                ViewBag.chatUsers = c.ChatUsersName;


            }
            else
            {
                cm.ChatAdd(c);
            }

            
            return View();
        }
        public IActionResult ChatUserMessage(string user, string otherUser, string users, string otherUsers)
        {
            List<ChatMessage> messageList = new List<ChatMessage>();
            var usersMessage = cmm.GetList();
            foreach (var item in usersMessage)
            {
                if (users == item.ChatMessageUsersName || otherUsers == item.ChatMessageUsersName)
                {
                    messageList.Add(item);
                }
            }
            
            
            return RedirectToAction("Index","Chat",new {messList = messageList});
        }

        



        public IActionResult ChatCounter(string msg,string Users, string first, string second)
        {
            ChatMessage c = new ChatMessage();
            c.ChatMessageFirstUserName = first;
            c.ChatMessageSecondUserName = second;
            c.ChatMessageUsersName = Users;
            c.ChatMessageContent = msg;
            cmm.ChatMessageAdd(c);

            msg = JsonConvert.SerializeObject(msg);
            return Json(msg);
        }
        

    }
}

