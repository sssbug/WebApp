using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Why.Data.Models
{
    public class ChatMessage
    {
        [Key]
        public int ChatMessageId { get; set; }
        public string ChatMessageFirstUserName { get; set; }
        public string ChatMessageSecondUserName { get; set; }
        public string ChatMessageUsersName { get; set; }
        public string ChatMessageContent { get; set; }
        public Chat Chat { get; set; }
    }
}
