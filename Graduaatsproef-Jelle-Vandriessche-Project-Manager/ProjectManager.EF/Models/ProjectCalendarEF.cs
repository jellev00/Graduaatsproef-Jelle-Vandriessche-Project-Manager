﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Models
{
    public class ProjectCalendarEF
    {
        [Key]
        public int Project_CalendarID { get; set; }

        [ForeignKey("project")]
        public int Project_ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public ProjectsEF project { get; set; }
    }
}