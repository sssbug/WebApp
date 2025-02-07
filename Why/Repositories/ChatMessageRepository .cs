using System.Collections.Generic;
using System.Linq;
using Why.Abstract;
using Why.Data;
using Why.Data.Models;

namespace Why.Repositories
{
    public class ChatMessageRepository : IChatMessageDal
    {
        WhyDbContext context = new WhyDbContext();
        public void AddChatMessage(ChatMessage chatMessage)
        {
            context.Add(chatMessage);
            context.SaveChanges();
        }

        public ChatMessage GetById(int id)
        {
            return context.ChatMessages.Find(id);
        }

        public List<ChatMessage> ListAllChatMessage()
        {
            return context.ChatMessages.ToList();
        }

        public void RemoveChatMessage(ChatMessage chatMessage)
        {
            if (chatMessage != null)
            {
                context.Remove(chatMessage);
                context.SaveChanges();
            }
            
        }

        public void UpdateChatMessage(ChatMessage chatMessage)
        {
            context.Update(chatMessage);
            context.SaveChanges();
        }
    }
}
