using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hackathon.Models
{
    public partial class Lecture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LectureId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? LectDate { get; set; }
        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
