using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class APIDocumentation : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string SampleImplementation { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
