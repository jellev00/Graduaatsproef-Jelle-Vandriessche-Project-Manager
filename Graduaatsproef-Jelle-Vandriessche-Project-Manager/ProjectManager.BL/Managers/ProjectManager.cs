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
    public class ProjectManager
    {
        private IProjectRepo _repo;
        private IUserRepo _userRepo;

        public ProjectManager(IProjectRepo repo, IUserRepo userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }

        // POST
        public void AddTaskToProject(int projectId, ProjectTasks projectTask)
        {
            try
            {
                if (projectTask == null)
                {
                    throw new ProjectsException("AddTaskToProject");
                }
                if (_repo.ProjectTasksExistsId(projectTask.TaskId))
                {
                    throw new ProjectsException("AddTaskToProject - Task Already exists!");
                }

                _repo.AddTaskToProject(projectId, projectTask);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("AddTaskToProject", ex);
            }
        }

        // GET
        public Project GetProjectById(int projectId)
        {
            try
            {
                if (!_userRepo.ProjectExistsId(projectId))
                {
                    throw new ProjectsException("GetProjectById - Project doesn't exist!");
                }
                return _repo.GetProjectById(projectId);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("GetProjectById", ex);
            }
        }

        // DELETE
        public void DeleteProjectTask(int projectTaskId)
        {
            try
            {
                if (!_repo.ProjectTasksExistsId(projectTaskId))
                {
                    throw new ProjectsException("DeleteProjectTask - Task doesn't exist!");
                }
                _repo.DeleteProjectTask(projectTaskId);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("DeleteProjectTask", ex);
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
                throw new ProjectsException("UpdateTaskStatus", ex);
            }
        }

        // Exists
        public bool ProjectTasksExistsId(int taskId)
        {
            try
            {
                return _repo.ProjectTasksExistsId(taskId);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("ProjectTasksExistsId", ex);
            }
        }
    }
}
