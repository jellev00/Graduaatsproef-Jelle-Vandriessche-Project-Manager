using ProjectManager.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_UI.Data
{
    public class InsertData
    {
        public List<User> Users()
        {
            List<User> users = new List<User>();

            User user1 = new User("Jelle", "Vandriessche", "jelle.vandriessche@gmail.com", "Root1234");
            User user2 = new User("John", "Doe", "john.doe@example.com", "password1");

            users.Add(user1);
            users.Add(user2);

            return users;
        }

        public List<Project> Projects()
        {
            List <Project> projects = new List<Project>();

            Project project1 = new Project(1, "Project A", "Description for Project A", "#58AEFF");
            Project project2 = new Project(2, "Project B", "Description for Project B", "#E9527D");

            projects.Add(project1);
            projects.Add(project2);

            return projects;
        }

        public List<UserTasks> UserTasks()
        {
            List<UserTasks> userTasks = new List<UserTasks>();

            UserTasks userTasks1 = new UserTasks(1, "Task 1", "Task 1 for Jelle Vandriessche", "#58AEFF");
            UserTasks userTasks2 = new UserTasks(1, "Task 2", "Task 2 for Jelle Vandriessche", "#E9527D");
            UserTasks userTasks3 = new UserTasks(2, "Task 1", "Task 1 for John Doe", "#58AEFF");

            userTasks.Add(userTasks1);
            userTasks.Add(userTasks2);
            userTasks.Add(userTasks3);

            return userTasks;
        }

        public List<ProjectTasks> ProjectTasks()
        {
            List<ProjectTasks> projectTasks = new List<ProjectTasks>();

            ProjectTasks projectTasks1 = new ProjectTasks(1, "Task 1", "Task 1 for Project A", "#58AEFF");
            ProjectTasks projectTasks2 = new ProjectTasks(1, "Task 2", "Task 2 for Project A", "#E9527D");
            ProjectTasks projectTasks3 = new ProjectTasks(2, "Task 1", "Task 1 for Project B", "#58AEFF");

            projectTasks.Add(projectTasks1);
            projectTasks.Add(projectTasks2);
            projectTasks.Add(projectTasks3);

            return projectTasks;
        }

        public List<ProjectCalendar> ProjectCalendar()
        {
            List<ProjectCalendar> projectCalendar = new List<ProjectCalendar>();

            ProjectCalendar projectCalendar1 = new ProjectCalendar(1, "Calendar for Project A", "Calendar Description", DateTime.Now);
            ProjectCalendar projectCalendar2 = new ProjectCalendar(2, "Calendar for Project B", "Calendar Description", DateTime.Now);

            projectCalendar.Add(projectCalendar1);
            projectCalendar.Add(projectCalendar2);

            return projectCalendar;
        }
    }
}
