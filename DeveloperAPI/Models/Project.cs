using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class Project : BaseEntity
    {
        [Key]
        public string ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }

        public ProjectStatusType Status { get; set; } = ProjectStatusType.Open;

        [ForeignKey("UserID")]
        public User ScrumMaster { get; set; }
        public List<Sprint> Sprints { get; set; } = new List<Sprint>();

        public enum ProjectStatusType //lets discuss this one further nlng
        {
            Open,
            RA,
            Development,
            Test,
            Closed
        }
    }
}
