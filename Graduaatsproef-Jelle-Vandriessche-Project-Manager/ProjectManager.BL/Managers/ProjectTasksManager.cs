using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Models;
using ProjectManager.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Managers
{
    public class ProjectTasksManager
    {
        private IProjectTasksRepo _repo;
        public ProjectTasksManager(IProjectTasksRepo repo)
        {
            _repo = repo;
        }

        public void AddTask(ProjectTasks projectTasks)
        {
            try
            {
                if (projectTasks == null)
                {
                    throw new ProjectTasksException("AddTask");
                }
                _repo.AddTask(projectTasks);
            } 
            catch (Exception ex)
            {
                throw new ProjectTasksException("AddTask", ex);
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                if (!_repo.TaskExists(taskId))
                {
                    throw new ProjectTasksException("DeleteTask");
                }
                _repo.DeleteTask(taskId);
            }
            catch (Exception ex)
            {
                throw new ProjectTasksException("DeleteTask", ex);
            }
        }

        public List<ProjectTasks> GetAllTasks(int projectId)
        {
            try
            {
                return _repo.GetAllTasks(projectId).Result;
            }
            catch (Exception ex)
            {
                throw new ProjectTasksException("GetAllTasks", ex);
            }
        }

        public bool TaskExists(int taskId)
        {
            try
            {
                return _repo.TaskExists(taskId);
            }
            catch (Exception ex)
            {
                throw new ProjectTasksException("TaskExists", ex);
            }
        }
    }
}
