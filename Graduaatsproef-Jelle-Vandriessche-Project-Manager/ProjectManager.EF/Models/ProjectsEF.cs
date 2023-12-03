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

        public ProjectsEF(int user_ID, string name, string description, string color)
        {
            User_ID = user_ID;
            Name = name;
            Description = description;
            Color = color;
        }

        public ProjectsEF(int project_ID, int user_ID, string name, string description, string color)
        {
            Project_ID = project_ID;
            User_ID = user_ID;
            Name = name;
            Description = description;
            Color = color;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_ID { get; set; }

        [ForeignKey("user")]
        public int User_ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Color { get; set; }

        public UserEF user { get; set; }

        public List<ProjectTasksEF> ProjectTasks { get; set; }
        public List<ProjectCalendarEF> ProjectCalendar { get; set; }
    }
}
