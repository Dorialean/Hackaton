using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            SessionHandlers = new HashSet<SessionHandler>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public string? Identifier { get; set; }

        public virtual ICollection<SessionHandler> SessionHandlers { get; set; }
    }
}
