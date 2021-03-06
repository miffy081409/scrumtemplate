﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperAPI.Models
{
    public class Bug : Task
    {
        //we need specific fields here

        public string SprintID { get; set; }

        [ForeignKey("SprintID")]
        public Sprint Sprint { get; set; }
    }
}
