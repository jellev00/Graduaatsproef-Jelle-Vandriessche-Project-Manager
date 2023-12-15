using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Models
{
    public class UserTasksEF
    {
        public UserTasksEF()
        {
        }

        public UserTasksEF(int user_ID, string task_Name, string task_Description, string color)
        {
            User_ID = user_ID;
            Task_Name = task_Name;
            Task_Description = task_Description;
            Color = color;
        }

        public UserTasksEF(int task_ID, int user_ID, string task_Name, string task_Description, string color)
        {
            Task_ID = task_ID;
            User_ID = user_ID;
            Task_Name = task_Name;
            Task_Description = task_Description;
            Color = color;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Task_ID { get; set; }

        [ForeignKey("user")]
        public int User_ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Task_Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Task_Description { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Color { get; set; }

        public UserEF user { get; set; }
    }
}
