using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class BaseEntity
    {
        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}
