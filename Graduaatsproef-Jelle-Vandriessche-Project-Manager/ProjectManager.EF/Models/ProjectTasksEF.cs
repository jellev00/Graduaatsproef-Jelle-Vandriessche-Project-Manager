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

        public ProjectTasksEF(ProjectsEF project, string task_Name, string task_Description, string color, DateTime date, bool status)
        {
            Project = project;
            Task_Name = task_Name;
            Task_Description = task_Description;
            Color = color;
            Date = date;
            Status = status;
        }

        public ProjectTasksEF(int project_Task_ID, ProjectsEF project, string task_Name, string task_Description, string color, DateTime date, bool status)
        {
            Project_Task_ID = project_Task_ID;
            Project = project;
            Task_Name = task_Name;
            Task_Description = task_Description;
            Color = color;
            Date = date;
            Status = status;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_Task_ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Task_Name { get; set; }

        [Column(TypeName = "varchar(400)")]
        public string Task_Description { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Color { get; set; }

        public DateTime Date { get; set; }

        public ProjectsEF Project { get; set; }

        public bool Status { get; set; }
    }
}
