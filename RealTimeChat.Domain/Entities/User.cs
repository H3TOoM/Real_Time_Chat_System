using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealTimeChat.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string UserName { get; private set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsOnline { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private readonly List<ConversationUser> _conversations = new();
        public IReadOnlyCollection<ConversationUser> Conversations => _conversations.AsReadOnly();

        private User() { }

        public User(string userName, string email, string passwordHash)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            IsOnline = false;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetOnline() => IsOnline = true;
        public void SetOffline() => IsOnline = false;
    }
}