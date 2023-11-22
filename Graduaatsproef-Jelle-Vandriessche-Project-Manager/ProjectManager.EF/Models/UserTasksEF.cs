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
        [Key]
        public int Task_ID { get; set; }

        [ForeignKey("user")]
        public int User_ID { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Task_Description { get; set; }

        public UserEF user { get; set; }
    }
}
