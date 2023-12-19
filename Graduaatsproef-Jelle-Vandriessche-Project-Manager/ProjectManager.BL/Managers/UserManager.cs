using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Models;
using ProjectManager.BL.Exceptions;

namespace ProjectManager.BL.Managers
{
    public class UserManager 
    {
        private IUserRepo _repo;

        public UserManager(IUserRepo repo)
        {
            _repo = repo;
        }

        // POST
        public void AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new UserException("AddUser");
                }
                if (_repo.UserExistsEmail(user.Email))
                {
                    throw new UserException("AddUser - User Already exists!");
                }

                _repo.AddUser(user);
            } catch (Exception ex)
            {
                throw new UserException("AddUser", ex);
            }
        }
        public void AddTaskToUser(int userId, UserTasks userTask)
        {
            try
            {
                if (userTask == null)
                {
                    throw new UserException("AddTaskToUser");
                }
                if (_repo.UserTaskExistsId(userTask.TaskId))
                {
                    throw new UserException("AddTaskToUser - Task Already exists!");
                }

                _repo.AddTaskToUser(userId, userTask);
            }
            catch (Exception ex)
            {
                throw new UserException("AddTaskToUser", ex);
            }
        }
        public void AddProjectToUser(int userId, Project project)
        {
            try
            {
                if (project == null)
                {
                    throw new UserException("AddProjectToUser");
                }
                if (_repo.ProjectExistsId(project.ProjectId))
                {
                    throw new UserException("AddProjectToUser - Project Already exists!");
                }

                _repo.AddProjectToUser(userId, project);
            }
            catch (Exception ex)
            {
                throw new UserException("AddProjectToUser", ex);
            }
        }

        // GET
        public User GetUserById(int userId)
        {
            try
            {
                if (!_repo.UserExistsId(userId))
                {
                    throw new UserException("GetUserById - User doesn't exist!");
                }
                return _repo.GetUserById(userId);
            }
            catch (Exception ex)
            {
                throw new UserException("GetUserById", ex);
            }
        }
        public User GetUserByEmail(string email)
        {
            try
            {
                if (!_repo.UserExistsEmail(email))
                {
                    throw new UserException("GetUserByEmail - User doesn't exist!");
                }
                return _repo.GetUserByEmail(email);
            }
            catch (Exception ex)
            {
                throw new UserException("GetUserByEmail", ex);
            }
        }

        // DELETE
        public void DeleteUser(string email)
        {
            try
            {
                if (!_repo.UserExistsEmail(email))
                {
                    throw new UserException("DeleteUser - User doesn't exist!");
                }
                _repo.DeleteUser(email);
            }
            catch (Exception ex)
            {
                throw new UserException("DeleteUser", ex);
            }
        }
        public void DeleteTask(int taskId)
        {
            try
            {
                if (!_repo.UserTaskExistsId(taskId))
                {
                    throw new UserException("DeleteTask - Task doesn't exist!");
                }
                _repo.DeleteTask(taskId);
            }
            catch (Exception ex)
            {
                throw new UserException("DeleteTask", ex);
            }
        }
        public void DeleteProject(int projectId)
        {
            try
            {
                if (!_repo.ProjectExistsId(projectId))
                {
                    throw new UserException("DeleteProject - Project doesn't exist!");
                }
                _repo.DeleteProject(projectId);
            }
            catch (Exception ex)
            {
                throw new UserException("DeleteProject", ex);
            }
        }

        // UPDATE
        public void UpdateTaskStatus(int taskId, bool newStatus)
        {
            try
            {
                _repo.UpdateTaskStatus(taskId, newStatus);
            }
            catch (Exception ex)
            {
                throw new UserException("UpdateTaskStatus", ex);
            }
        }

        // EXISTS
        public bool UserExistsEmail(string email)
        {
            try
            {
                return _repo.UserExistsEmail(email);
            }
            catch (Exception ex)
            {
                throw new UserException("UserExistsEmail", ex);
            }
        }
        public bool UserExistsId(int userId)
        {
            try
            {
                return _repo.UserExistsId(userId);
            }
            catch (Exception ex)
            {
                throw new UserException("UserExistsId", ex);
            }
        }
        public bool UserTaskExistsId(int taskId)
        {
            try
            {
                return _repo.UserTaskExistsId(taskId);
            }
            catch (Exception ex)
            {
                throw new UserException("UserTaskExistsId", ex);
            }
        }
        public bool ProjectExistsId(int projectId)
        {
            try
            {
                return _repo.ProjectExistsId(projectId);
            }
            catch (Exception ex)
            {
                throw new UserException("ProjectExistsId", ex);
            }
        }
    }
}
