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
        public ProjectCalendarEF()
        {
        }

        public ProjectCalendarEF(ProjectsEF project, string name, string description, DateTime date)
        {
            Project = project;
            Name = name;
            Description = description;
            Date = date;
        }

        public ProjectCalendarEF(int project_CalendarID, ProjectsEF project, string name, string description, DateTime date)
        {
            Project_CalendarID = project_CalendarID;
            Project = project;
            Name = name;
            Description = description;
            Date = date;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_CalendarID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public ProjectsEF Project { get; set; }
    }
}
