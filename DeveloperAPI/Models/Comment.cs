using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public string CommentID { get; set; }
        public string Message { get; set; }

        public virtual User User { get; set; }
    }
}
