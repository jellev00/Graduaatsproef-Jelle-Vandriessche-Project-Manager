using ProjectManager.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_UI.Data;

namespace Test_UI.Manager
{
    public class InserManager
    {
        public List<User> InsertUsers()
        {
            InsertData data = new InsertData();
            List<User> users = data.Users();
            return users;
        }

        public List<Project> InsertProjects()
        {
            InsertData data = new InsertData();
            List<Project> project = data.Projects();
            return project;
        }

        public List<UserTasks> InsertUserTasks()
        {
            InsertData data = new InsertData();
            List<UserTasks> userTasks = data.UserTasks();
            return userTasks;
        }

        public List<ProjectTasks> InsertProjectTasks()
        {
            InsertData data = new InsertData();
            List<ProjectTasks> projectTasks = data.ProjectTasks();
            return projectTasks;
        }

        public List<ProjectCalendar> InsertProjectCalendar()
        {
            InsertData data = new InsertData();
            List<ProjectCalendar> projectCalendar = data.ProjectCalendar();
            return projectCalendar;
        }
    }
}
