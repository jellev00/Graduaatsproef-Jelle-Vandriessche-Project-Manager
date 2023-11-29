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
        public ProjectTasksEF()
        {
        }

        public ProjectTasksEF(int project_ID, string task_Description)
        {
            Project_ID = project_ID;
            Task_Description = task_Description;
        }

        public ProjectTasksEF(int project_Task_ID, int project_ID, string task_Description)
        {
            Project_Task_ID = project_Task_ID;
            Project_ID = project_ID;
            Task_Description = task_Description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_Task_ID { get; set; }

        [ForeignKey("project")]
        public int Project_ID { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Task_Description { get; set; }

        public ProjectsEF project { get; set; }
    }
}
