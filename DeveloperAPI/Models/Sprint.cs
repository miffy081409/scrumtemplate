using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class Sprint : BaseEntity
    {
        [Key]
        public string SprintID { get; set; }
        public string ProjectID { get; set; }
        //add date estimates here

        public DateTime DateStarted { get; set; } = DateTime.Now;
        public DateTime DateEnded { get; set; } = DateTime.Now;


        public TimeSpan TimeElapsed
        {
            get
            {
                return this.DateEnded - this.DateStarted;
            }
        }

        [ForeignKey("ProjectID")]
        public Project Project { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
