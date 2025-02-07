using System.Collections.Generic;
using Why.Data.Models;

namespace Why.AbstractServices
{
    public interface IChatService
    {
        void ChatAdd(Chat chat);
        void ChatRemove(Chat chat);
        void ChatUpdate(Chat chat);
        List<Chat> GetList();
        Chat GetbyId(int id);
    }
}
