using System.Collections.Generic;
using Why.Data.Models;

namespace Why.Abstract
{
    public interface IChatDal
    {
        List<Chat> ListAllChat();
        void AddChat(Chat chat);
        void RemoveChat(Chat chat);
        void UpdateChat(Chat chat);
        Chat GetById(int id);
    }
}
