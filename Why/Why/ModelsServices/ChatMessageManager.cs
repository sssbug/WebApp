using System.Collections.Generic;
using Why.Abstract;
using Why.AbstractServices;
using Why.Data.Models;
using Why.Repositories;

namespace Why.ModelsServices
{
    public class ChatMessageManager : IChatMessageService
    {
        IChatMessageDal _chatMessageDal;

        public ChatMessageManager(IChatMessageDal chatMessageDal)
        {
            _chatMessageDal = chatMessageDal;
        }

        public void ChatMessageRemove(ChatMessage chatMessage)
        {
            _chatMessageDal.RemoveChatMessage(chatMessage);
        }

        public void ChatMessageUpdate(ChatMessage chatMessage)
        {
            _chatMessageDal.UpdateChatMessage(chatMessage);
        }

        public ChatMessage GetbyId(int id)
        {
            return _chatMessageDal.GetById(id);
        }

        public List<ChatMessage> GetList()
        {
            return _chatMessageDal.ListAllChatMessage();
        }

        public void ChatMessageAdd(ChatMessage chatMessage)
        {
            _chatMessageDal.AddChatMessage(chatMessage);
        }
    }
}
