using System;
using System.Collections.Generic;

namespace Hackathon.Models
{
    public partial class UserData
    {
        public Guid UserDataId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public string? UserDataClass { get; set; }
    }
}
