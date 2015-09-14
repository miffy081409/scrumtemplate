using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public string CommentID { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public string TaskID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        [ForeignKey("TaskID")]
        public Task Task { get; set; }
    }
}
