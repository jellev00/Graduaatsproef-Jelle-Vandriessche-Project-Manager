using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Models;
using ProjectManager.EF.Exceptions;
using ProjectManager.EF.Mapper;
using ProjectManager.EF.Models;

namespace ProjectManager.EF.Repositories
{
    public class RepoUserEF : IUserRepo
    {
        private ContextEF ctx;

        public RepoUserEF(string connectionString)
        {
            this.ctx = new ContextEF(connectionString);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AddProjectToUser(int userId, Project project)
        {
            try
            {
                // Retrieve the User from the database
                UserEF user = ctx.Users.Find(userId);

                if (user == null)
                {
                    // Handle the case where the user is not found in the database
                    throw new RepoUserEFException($"User with ID {userId} not found.");
                }

                // Initialize UserTasks collection if it's null
                if (user.Projects == null)
                {
                    user.Projects = new List<ProjectsEF>();
                }

                // Map UserTasks to UserTasksEF
                ProjectsEF projectsEF = MapProjectEF.MapToDB(project, ctx);

                // Add the UserTasksEF to the User
                user.Projects.Add(projectsEF);

                // Save changes to the database
                SaveAndClear();
            } catch (Exception ex)
            {
                throw new RepoUserEFException("AddProjectToUser", ex);
            }
        }

        public void AddTaskToUser(int userId, UserTasks userTask)
        {
            try
            {
                // Retrieve the User from the database
                UserEF user = ctx.Users.Find(userId);

                if (user == null)
                {
                    // Handle the case where the user is not found in the database
                    throw new RepoUserEFException($"User with ID {userId} not found.");
                }

                // Initialize UserTasks collection if it's null
                if (user.UserTasks == null)
                {
                    user.UserTasks = new List<UserTasksEF>();
                }

                // Map UserTasks to UserTasksEF
                UserTasksEF userTasksEF = MapUserTasksEF.MapToDB(userTask, ctx);

                // Add the UserTasksEF to the User
                user.UserTasks.Add(userTasksEF);

                // Save changes to the database
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("AddTaskToUser", ex);
            }
        }

        public void AddUser(User user)
        {
            try
            {
                ctx.Add(MapUserEF.MapToDB(user, ctx));
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("AddUser", ex);
            }
        }

        public void DeleteProject(int projectId)
        {
            try
            {
                var ProjectToDelete = ctx.Projects.SingleOrDefault(x => x.Project_ID == projectId);

                if (ProjectToDelete != null)
                {
                    ctx.Projects.Remove(ProjectToDelete);
                    SaveAndClear();
                }
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("DeleteProject", ex);
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                var TaskToDelete = ctx.UserTasks.SingleOrDefault(x => x.Task_ID == taskId);

                if (TaskToDelete != null)
                {
                    ctx.UserTasks.Remove(TaskToDelete);
                    SaveAndClear();
                }
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("DeleteTask", ex);
            }
        }

        public void DeleteUser(string email)
        {
            try
            {
                var userToDelete = ctx.Users.SingleOrDefault(x => x.Email == email);

                if (userToDelete != null)
                {
                    ctx.Users.Remove(userToDelete);
                    SaveAndClear();
                }
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("DeleteUser", ex);
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return MapUserEF.MapToDomain(ctx.Users.Where(x => x.Email == email).Include(x => x.UserTasks).Include(x => x.Projects).AsNoTracking().FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("GetUserByEmail", ex);
            }
        }

        public User GetUserById(int userId)
        {
            try
            {
                return MapUserEF.MapToDomain(ctx.Users.Where(x => x.User_ID == userId).Include(x => x.UserTasks).Include(x => x.Projects).AsNoTracking().FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("GetUserById", ex);
            }
        }

        public bool ProjectExistsId(int projectId)
        {
            try
            {
                return ctx.Projects.Any(x => x.Project_ID == projectId);
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("ProjectExistsId", ex);
            }
        }

        public bool UserExistsEmail(string email)
        {
            try
            {
                return ctx.Users.Any(x => x.Email == email);
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("UserExistsEmail", ex);
            }
        }

        public bool UserExistsId(int userId)
        {
            try
            {
                return ctx.Users.Any(x => x.User_ID == userId);
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("UserExistsId", ex);
            }
        }

        public bool UserTaskExistsId(int taskId)
        {
            try
            {
                return ctx.UserTasks.Any(x => x.Task_ID == taskId);
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("UserTaskExistsId", ex);
            }
        }
    }
}
