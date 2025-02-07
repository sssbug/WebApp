using System.Collections.Generic;
using System.Linq;
using Why.Abstract;
using Why.Data;
using Why.Data.Models;

namespace Why.Repositories
{
    public class ChatRepository : IChatDal
    {
        WhyDbContext context = new WhyDbContext();
        public void AddChat(Chat chat)
        {
            context.Add(chat);
            context.SaveChanges();
        }

        public Chat GetById(int id)
        {
            return context.Chats.Find(id);
        }

        public List<Chat> ListAllChat()
        {
            return context.Chats.ToList();
        }

        public void RemoveChat(Chat chat)
        {
            if (chat != null)
            {
                context.Remove(chat);
                context.SaveChanges();
            }
            
        }

        public void UpdateChat(Chat chat)
        {
            context.Update(chat);
            context.SaveChanges();
        }
    }
}
