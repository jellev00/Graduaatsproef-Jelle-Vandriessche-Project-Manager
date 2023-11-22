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
        [Key]
        public int Project_ID { get; set; }

        [ForeignKey("user")]
        public int User_ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }

        public UserEF user { get; set; }

        public List<ProjectTasksEF> ProjectTasks { get; set; }
        public List<ProjectCalendarEF> ProjectCalendar { get; set; }
    }
}
