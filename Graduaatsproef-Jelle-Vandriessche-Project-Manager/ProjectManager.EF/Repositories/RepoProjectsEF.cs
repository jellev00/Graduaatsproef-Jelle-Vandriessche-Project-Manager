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

        public void AddCalendarToProject(int projectId, ProjectCalendar projectCalendar)
        {
            try
            {
                ProjectsEF project = ctx.Projects.Find(projectId);

                if (project == null)
                {
                    throw new RepoProjectsEFException($"project with ID {projectId} not found.");
                }

                if (project.ProjectCalendar == null)
                {
                    project.ProjectCalendar = new List<ProjectCalendarEF>();
                }

                ProjectCalendarEF calendarEF = MapProjectCalendarEF.MapToDB(projectCalendar, ctx);

                project.ProjectCalendar.Add(calendarEF);

                SaveAndClear();
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("AddTaskToProject", ex);
            }
        }

        public void DeleteProjectCalendar(int projectCalendarId)
        {
            try
            {
                var CalendarToDelete = ctx.ProjectCalendar.SingleOrDefault(x => x.Project_CalendarID == projectCalendarId);

                if (CalendarToDelete != null)
                {
                    ctx.ProjectCalendar.Remove(CalendarToDelete);
                    SaveAndClear();
                }
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("DeleteProjectCalendar", ex);
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
                return MapProjectEF.MapToDomain(ctx.Projects.Where(x => x.Project_ID == projectId).Include(x => x.User).Include(x => x.ProjectTasks).Include(x => x.ProjectCalendar).AsNoTracking().FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("GetProjectById", ex);
            }
        }

        public bool ProjectCalendarExistsId(int CalendarId)
        {
            try
            {
                return ctx.ProjectCalendar.Any(x => x.Project_CalendarID == CalendarId);
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("ProjectCalendarExistsId", ex);
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
