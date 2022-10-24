using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hackathon.Models
{
    public partial class SessionHandler
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid SessionId { get; set; }
        public string UserJwt { get; set; } = null!;
        public Guid UserId { get; set; }
        public DateTime StartTime { get; set; }

        public virtual UserLogin User { get; set; } = null!;
    }
}
