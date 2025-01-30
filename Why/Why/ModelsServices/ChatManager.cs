using System.Collections.Generic;
using Why.Abstract;
using Why.AbstractServices;
using Why.Data.Models;
using Why.Repositories;

namespace Why.ModelsServices
{
    public class ChatManager : IChatService
    {
        IChatDal _chatDal;

        public ChatManager(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }

        public void ChatRemove(Chat chat)
        {
            _chatDal.RemoveChat(chat);
        }

        public void ChatUpdate(Chat chat)
        {
            _chatDal.UpdateChat(chat);
        }

        public Chat GetbyId(int id)
        {
            return _chatDal.GetById(id);
        }

        public List<Chat> GetList()
        {
            return _chatDal.ListAllChat();
        }

        public void ChatAdd(Chat chat)
        {
            _chatDal.AddChat(chat);
        }
    }
}
