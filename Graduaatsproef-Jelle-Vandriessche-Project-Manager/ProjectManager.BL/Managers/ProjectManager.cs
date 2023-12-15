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
        public void AddCalendarToProject(int projectId, ProjectCalendar projectCalendar)
        {
            try
            {
                if (projectCalendar == null)
                {
                    throw new ProjectsException("AddCalendarToProject");
                }
                if (_repo.ProjectCalendarExistsId(projectCalendar.CalendarId))
                {
                    throw new ProjectsException("AddCalendarToProject - Calendar Already exists!");
                }

                _repo.AddCalendarToProject(projectId, projectCalendar);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("AddCalendarToProject", ex);
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
        public void DeleteProjectCalendar(int projectCalendarId)
        {
            try
            {
                if (!_repo.ProjectCalendarExistsId(projectCalendarId))
                {
                    throw new ProjectsException("DeleteProjectTask - Calendar doesn't exist!");
                }
                _repo.DeleteProjectCalendar(projectCalendarId);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("DeleteProjectTask", ex);
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
        public bool ProjectCalendarExistsId(int CalendarId)
        {
            try
            {
                return _repo.ProjectCalendarExistsId(CalendarId);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("ProjectCalendarExistsId", ex);
            }
        }
    }
}
