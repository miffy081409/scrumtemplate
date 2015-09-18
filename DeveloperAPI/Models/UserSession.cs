using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class UserSession:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }
        public String Token { get; set; }
        public DateTime Expiration { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

    }
}
