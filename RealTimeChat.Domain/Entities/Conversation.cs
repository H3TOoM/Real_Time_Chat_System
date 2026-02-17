using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealTimeChat.Domain.Entities
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        public bool IsGroup { get; private set; }
        [Required, StringLength(100)]
        public string? Title { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private readonly List<ConversationUser> _users = new();
        public IReadOnlyCollection<ConversationUser> Users => _users.AsReadOnly();

        private readonly List<Message> _messages = new();
        public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();

        private Conversation() { }

        public Conversation(bool isGroup, string? title)
        {
            IsGroup = isGroup;
            Title = isGroup ? title : null;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddUser(int userId)
        {
            if (_users.Any(cu => cu.UserId == userId))
                return;

            _users.Add(new ConversationUser(userId, Id));
        }

    }
}