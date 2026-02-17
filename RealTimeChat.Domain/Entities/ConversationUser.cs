using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealTimeChat.Domain.Entities
{
    public class ConversationUser
    {
        [Key]
        public int ConversationId { get; set; }

        public int UserId { get; private set; }

        public DateTime JoinedAt { get; private set; }

        private ConversationUser() { }

        public ConversationUser(int userId, int conversationId)
        {
            UserId = userId;
            ConversationId = conversationId;
            JoinedAt = DateTime.UtcNow;
        }

    }
}