using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Why.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Why.Data;
using Why.ModelsServices;
using Why.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Why.Hubs
{
    public class ChatHub:Hub
    {
       
        public async Task SendMessage(string fromUser, string message)
        {
             

             await Clients.All.SendAsync("ReceiveMessage", fromUser, message);
        }

    }
    
}
