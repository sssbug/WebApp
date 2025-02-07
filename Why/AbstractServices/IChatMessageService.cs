using System.Collections.Generic;
using Why.Data.Models;

namespace Why.AbstractServices
{
    public interface IChatMessageService
    {
        void ChatMessageAdd(ChatMessage chatMessage);
        void ChatMessageRemove(ChatMessage chatMessage);
        void ChatMessageUpdate(ChatMessage chatMessage);
        List<ChatMessage> GetList();
        ChatMessage GetbyId(int id);
    }
}
