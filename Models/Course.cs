using System;
using System.Collections.Generic;

namespace Hackathon.Models
{
    public partial class Course
    {
        public Course()
        {
            Lectures = new HashSet<Lecture>();
        }

        public Guid CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
