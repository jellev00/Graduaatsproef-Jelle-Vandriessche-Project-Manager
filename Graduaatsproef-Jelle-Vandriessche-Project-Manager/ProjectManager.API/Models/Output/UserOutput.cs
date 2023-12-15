using ProjectManager.BL.Models;

namespace ProjectManager.API.Models.Output
{
    public class UserOutput
    {
        public UserOutput(int userId, string first_Name, string last_Name, string email, string password, List<UserTasks> userTasks, List<Project> projects)
        {
            UserId = userId;
            First_Name = first_Name;
            Last_Name = last_Name;
            Email = email;
            Password = password;
            UserTasks = userTasks;
            Projects = projects;
        }

        public int UserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserTasks> UserTasks { get; set; }
        public List<Project> Projects { get; set; }
    }
}
