using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class Task : BaseEntity
    {
        [Key]
        public string TaskID { get; set; }
        public string UserID { get; set; }
        public string SprintID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriorityType Priority { get; set; } = TaskPriorityType.Medium;
        public DateTime DateStarted { get; set; } = DateTime.Now;
        public DateTime DateEnded { get; set; } = DateTime.Now;

        public TimeSpan TimeElapsed
        {
            get
            {
                return this.DateEnded - this.DateStarted;
            }
        }

        [ForeignKey("SprintID")]
        public Sprint Sprint { get; set; }
        [ForeignKey("UserID")]
        public User Assignee { get; set; }

        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public enum TaskPriorityType
        {
            High,
            Medium,
            Low
        }
    }
}
