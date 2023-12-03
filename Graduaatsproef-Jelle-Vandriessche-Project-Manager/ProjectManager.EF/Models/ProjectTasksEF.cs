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

        public ProjectTasksEF(int project_ID, string task_Name, string task_Description, string color)
        {
            Project_ID = project_ID;
            Task_Name = task_Name;
            Task_Description = task_Description;
            Color = color;
        }

        public ProjectTasksEF(int project_Task_ID, int project_ID, string task_Name, string task_Description, string color)
        {
            Project_Task_ID = project_Task_ID;
            Project_ID = project_ID;
            Task_Name= task_Name;
            Task_Description = task_Description;
            Color = color;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_Task_ID { get; set; }

        [ForeignKey("project")]
        public int Project_ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Task_Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Task_Description { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Color { get; set; }

        public ProjectsEF project { get; set; }
    }
}
