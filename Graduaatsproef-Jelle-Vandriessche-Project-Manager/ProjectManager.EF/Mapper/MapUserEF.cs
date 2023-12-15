using ProjectManager.BL.Models;
using ProjectManager.EF.Exceptions;
using ProjectManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Mapper
{
    public class MapUserEF
    {
        public static User MapToDomain(UserEF db)
        {
            try
            {
                List<UserTasks> userTasks = new List<UserTasks>();
                List<Project> projects = new List<Project>();

                if (db.UserTasks != null)
                {
                    foreach (UserTasksEF uT in db.UserTasks)
                    {
                        User user = new User(uT.User.User_ID, uT.User.First_Name, uT.User.Last_Name, uT.User.Email, uT.User.Password);
                        UserTasks userTask = new UserTasks(uT.Task_ID, user, uT.Task_Name, uT.Task_Description, uT.Color);

                        userTasks.Add(userTask);
                    }
                }

                if (db.Projects != null)
                {
                    foreach (ProjectsEF p in db.Projects)
                    {
                        User user = new User(p.User.User_ID, p.User.First_Name, p.User.Last_Name, p.User.Email, p.User.Password);
                        Project project = new Project(p.Project_ID, user, p.Name, p.Description, p.Color);

                        projects.Add(project);
                    }
                }

                return new User(db.User_ID, db.First_Name, db.Last_Name, db.Email, db.Password, userTasks, projects);

            }
            catch (Exception ex)
            {
                throw new MapEFException("MapUser - MapToDomain", ex);
            }
        }

        public static UserEF MapToDB(User u, ContextEF ctx)
        {
            try
            {
                UserEF user = ctx.Users.Find(u.UserId);

                List<UserTasksEF> userTasks = new List<UserTasksEF>();
                List<ProjectsEF> projects = new List<ProjectsEF>();

                if (u.UserTasks != null)
                {
                    foreach (UserTasks tasks in u.UserTasks.ToList())
                    {
                        UserTasksEF userTasksEF = MapUserTasksEF.MapToDB(tasks, ctx);
                        userTasks.Add(userTasksEF);
                    }
                }

                if (u.Projects != null)
                {
                    foreach (Project project in u.Projects.ToList())
                    {
                        ProjectsEF projectsEF = MapProjectEF.MapToDB(project, ctx);
                        projects.Add(projectsEF);
                    }
                }

                if (user == null)
                {
                    // Create a new User if it doesn't exist
                    user = new UserEF(u.First_Name, u.Last_Name, u.Email, u.Password, projects, userTasks);
                    ctx.Users.Add(user);
                }
                else
                {
                    // Update existing User
                    user.First_Name = u.First_Name;
                    user.Last_Name = u.Last_Name;
                    user.Email = u.Email;
                    user.Password = u.Password;

                    // Update relationships
                    user.UserTasks = userTasks;
                    user.Projects = projects;
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapUser - MapToDB", ex);
            }
        }
    }
}
