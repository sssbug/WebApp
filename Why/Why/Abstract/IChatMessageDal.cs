using System.Collections.Generic;
using Why.Data.Models;

namespace Why.Abstract
{
    public interface IChatMessageDal
    {
        List<ChatMessage> ListAllChatMessage();
        void AddChatMessage(ChatMessage chatMessage);
        void RemoveChatMessage(ChatMessage chatMessage);
        void UpdateChatMessage(ChatMessage chatMessage);
        ChatMessage GetById(int id);
    }
}
