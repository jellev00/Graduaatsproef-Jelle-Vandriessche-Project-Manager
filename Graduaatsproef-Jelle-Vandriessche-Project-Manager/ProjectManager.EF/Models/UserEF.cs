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
        public UserEF()
        {
            // Default constructor
        }

        public UserEF(string first_name, string last_name, string email, string password)
        {
            First_Name = first_name;
            Last_Name = last_name;
            Email = email;
            Password = password;
        }

        public UserEF(int user_ID, string first_name, string last_name, string email, string password)
        {
            User_ID = user_ID;
            First_Name = first_name;
            Last_Name = last_name;
            Email = email;
            Password = password;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_ID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string First_Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Last_Name { get; set; }

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
