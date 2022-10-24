using System;
using System.Collections.Generic;

namespace Hackathon.Models
{
    public partial class SessionHandler
    {
        public Guid SessionId { get; set; }
        public string UserJwt { get; set; } = null!;
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }

        public virtual UserLogin User { get; set; } = null!;
    }
}
