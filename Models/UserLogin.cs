using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hackathon.Models
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            SessionHandlers = new HashSet<SessionHandler>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public string? Identifier { get; set; }

        public virtual ICollection<SessionHandler> SessionHandlers { get; set; }
    }
}
