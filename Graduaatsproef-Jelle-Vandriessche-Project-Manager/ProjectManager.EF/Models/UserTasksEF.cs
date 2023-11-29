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

        public UserTasksEF(int user_ID, string task_Description)
        {
            User_ID = user_ID;
            Task_Description = task_Description;
        }

        public UserTasksEF(int task_ID, int user_ID, string task_Description)
        {
            Task_ID = task_ID;
            User_ID = user_ID;
            Task_Description = task_Description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Task_ID { get; set; }

        [ForeignKey("user")]
        public int User_ID { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Task_Description { get; set; }

        public UserEF user { get; set; }
    }
}
