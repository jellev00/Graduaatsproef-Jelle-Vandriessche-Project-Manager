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

        public UserTasksEF(UserEF user, string task_Name, string task_Description, string color, DateTime date)
        {
            User = user;
            Task_Name = task_Name;
            Task_Description = task_Description;
            Color = color;
            Date = date;
        }

        public UserTasksEF(int task_ID, UserEF user, string task_Name, string task_Description, string color, DateTime date)
        {
            Task_ID = task_ID;
            User = user;
            Task_Name = task_Name;
            Task_Description = task_Description;
            Color = color;
            Date = date;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Task_ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Task_Name { get; set; }

        [Column(TypeName = "varchar(400)")]
        public string Task_Description { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Color { get; set; }

        public DateTime Date { get; set; }

        public UserEF User { get; set; }
    }
}
