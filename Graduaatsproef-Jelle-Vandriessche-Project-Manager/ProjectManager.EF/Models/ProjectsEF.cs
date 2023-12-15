using ProjectManager.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Models
{
    public class ProjectsEF
    {
        public ProjectsEF()
        {
        }

        public ProjectsEF(UserEF user, string name, string description, string color)
        {
            User = user;
            Name = name;
            Description = description;
            Color = color;
        }

        public ProjectsEF(int project_ID, UserEF user, string name, string description, string color)
        {
            Project_ID = project_ID;
            User = user;
            Name = name;
            Description = description;
            Color = color;
        }

        public ProjectsEF(int project_ID, UserEF user, string name, string description, string color, List<ProjectTasksEF> projectTasks, List<ProjectCalendarEF> projectCalendar)
        {
            Project_ID = project_ID;
            Name = name;
            Description = description;
            Color = color;
            User = user;
            ProjectTasks = projectTasks;
            ProjectCalendar = projectCalendar;
        }

        public ProjectsEF(UserEF user, string name, string description, string color, List<ProjectTasksEF> projectTasks, List<ProjectCalendarEF> projectCalendar)
        {
            Name = name;
            Description = description;
            Color = color;
            User = user;
            ProjectTasks = projectTasks;
            ProjectCalendar = projectCalendar;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Color { get; set; }

        public UserEF User { get; set; }

        public List<ProjectTasksEF> ProjectTasks { get; set; }
        public List<ProjectCalendarEF> ProjectCalendar { get; set; }
    }
}
