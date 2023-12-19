using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class RepoProjectsEF : IProjectRepo
    {
        private ContextEF ctx;

        public RepoProjectsEF(string connectionString)
        {
            this.ctx = new ContextEF(connectionString);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AddTaskToProject(int projectId, ProjectTasks projectTask)
        {
            try
            {
                ProjectsEF project = ctx.Projects.Find(projectId);

                if (project == null)
                {
                    throw new RepoProjectsEFException($"project with ID {projectId} not found.");
                }

                if (project.ProjectTasks == null)
                {
                    project.ProjectTasks = new List<ProjectTasksEF>();
                }

                ProjectTasksEF tasksEF = MapProjectTasksEF.MapToDB(projectTask, ctx);

                project.ProjectTasks.Add(tasksEF);

                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("AddTaskToProject", ex);
            }
        }

        public void UpdateTaskStatus(int taskId, bool newStatus)
        {
            try
            {
                // Retrieve the UserTask from the database
                ProjectTasksEF taskToUpdate = ctx.ProjectTasks.Find(taskId);

                if (taskToUpdate == null)
                {
                    // Handle the case where the task is not found in the database
                    throw new RepoUserEFException($"Task with ID {taskId} not found.");
                }

                // Update the status
                taskToUpdate.Status = newStatus;

                // Save changes to the database
                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("UpdateTaskStatus", ex);
            }
        }

        public void DeleteProjectTask(int projectTaskId)
        {
            try
            {
                var TaskToDelete = ctx.ProjectTasks.SingleOrDefault(x => x.Project_Task_ID == projectTaskId);

                if (TaskToDelete != null)
                {
                    ctx.ProjectTasks.Remove(TaskToDelete);
                    SaveAndClear();
                }
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("DeleteProjectTask", ex);
            }
        }

        public Project GetProjectById(int projectId)
        {
            try
            {
                return MapProjectEF.MapToDomain(ctx.Projects.Where(x => x.Project_ID == projectId).Include(x => x.User).Include(x => x.ProjectTasks).AsNoTracking().FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("GetProjectById", ex);
            }
        }

        public bool ProjectTasksExistsId(int taskId)
        {
            try
            {
                return ctx.ProjectTasks.Any(x => x.Project_Task_ID == taskId);
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("ProjectTasksExistsId", ex);
            }
        }
    }
}
