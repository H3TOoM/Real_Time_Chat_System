using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeChat.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int ConversationId { get; private set; }
        public int SenderId { get; private set; }

        public string Content { get; private set; }
        public bool IsRead { get; private set; }
        public DateTime SentAt { get; private set; }

        private Message() { }
        public Message(int conversationId, int senderId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Message content cannot be empty.", nameof(content));


            ConversationId = conversationId;
            SenderId = senderId;
            Content = content;
            IsRead = false;
            SentAt = DateTime.UtcNow;
        }

        public void MarkAsRead()
        {
            if (!IsRead) IsRead = true;
            IsRead = true;
        }
    }
}