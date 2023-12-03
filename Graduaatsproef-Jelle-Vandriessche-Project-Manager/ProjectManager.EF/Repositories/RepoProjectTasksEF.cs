using Microsoft.EntityFrameworkCore;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Models;
using ProjectManager.EF.Exceptions;
using ProjectManager.EF.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectManager.EF.Repositories
{
    public class RepoProjectTasksEF : IProjectTasksRepo
    {
        private ContextEF ctx;

        public RepoProjectTasksEF(string connectionString)
        {
            this.ctx = new ContextEF(connectionString);
        }

        public void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AddTask(ProjectTasks projectTask)
        {
            try
            {
                ctx.Add(MapProjectTasksEF.MapToDB(projectTask));
                ctx.SaveChanges();
            } 
            catch (Exception ex)
            {
                throw new RepoProjectTasksEFException("AddTask", ex);
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                var projectTaskToDelete = ctx.ProjectTasks.SingleOrDefault(x => x.Project_Task_ID == taskId);

                if (projectTaskToDelete != null)
                {
                    ctx.ProjectTasks.Remove(projectTaskToDelete);
                    ctx.SaveChanges();
                }
            } 
            catch (Exception ex)
            {
                throw new RepoProjectTasksEFException("DeleteTask", ex);
            }
        }

        public async Task<List<ProjectTasks>> GetAllTasks(int projectId)
        {
            try
            {
                var tasks = await ctx.ProjectTasks.Where(x => x.Project_ID == projectId).AsNoTracking().ToListAsync();

                return tasks.Select(MapProjectTasksEF.MapToDomain).ToList();
            }
            catch (Exception ex)
            {
                throw new RepoProjectTasksEFException("GetAllTasks", ex);
            }
        }

        public bool TaskExists(int taskId)
        {
            try
            {
                return ctx.ProjectTasks.Any(x => x.Project_Task_ID == taskId);
            }
            catch (Exception ex)
            {
                throw new RepoProjectTasksEFException("TaskExists", ex);
            }
        }
    }
}
