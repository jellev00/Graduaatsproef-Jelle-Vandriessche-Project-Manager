using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Models
{
    public class ProjectTasksEF
    {
        [Key]
        public int Project_Task_ID { get; set; }

        [ForeignKey("project")]
        public int Project_ID { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Task_Description { get; set; }

        public ProjectsEF project { get; set; }
    }
}
