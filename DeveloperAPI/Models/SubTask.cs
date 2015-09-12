using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class SubTask : Task
    {
        public string ParentID { get; set; }

        [ForeignKey("ParentID")]
        public Task Parent { get; set; }
    }
}
