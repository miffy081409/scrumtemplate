using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DeveloperAPI.Models
{
    public class User : BaseEntity
    {
        [Key]
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsScrumMaster { get; set; }
        //public string Token { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<UserSession> Sessions { get; set; } = new List<UserSession>();
    }
}
