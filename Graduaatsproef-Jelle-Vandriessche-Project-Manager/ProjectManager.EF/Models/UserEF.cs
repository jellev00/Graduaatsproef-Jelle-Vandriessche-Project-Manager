using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Models
{
    public class UserEF
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

        public List<ProjectsEF> Projects { get; set; }
        public List<UserTasksEF> UserTasks { get; set; }
    }
}
