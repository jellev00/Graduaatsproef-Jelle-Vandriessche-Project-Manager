using Microsoft.EntityFrameworkCore;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Models;
using ProjectManager.EF.Exceptions;
using ProjectManager.EF.Mapper;
using ProjectManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Repositories
{
    public class RepoUserTasksEF : IUserTasksRepo
    {
        private ContextEF ctx;

        public RepoUserTasksEF(string connectionString)
        {
            this.ctx = new ContextEF(connectionString);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AddTask(UserTasks userTask)
        {
            try
            {
                ctx.Add(MapUserTasksEF.MapToDB(userTask));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepoUserTasksEFException("AddTask", ex);
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                var userTaskToDelete = ctx.UserTasks.SingleOrDefault(x => x.Task_ID == taskId);

                if (userTaskToDelete != null)
                {
                    ctx.UserTasks.Remove(userTaskToDelete);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RepoUserTasksEFException("DeleteTask", ex);
            }
        }

        public async Task<List<UserTasks>> GetAllTasks(int userId)
        {
            try
            {
                var tasks = await ctx.UserTasks.Where(x => x.User_ID == userId).AsNoTracking().ToListAsync();

                return tasks.Select(MapUserTasksEF.MapToDomain).ToList();
            }
            catch (Exception ex)
            {
                throw new RepoUserTasksEFException("GetAllTasks", ex);
            }
        }

        public bool TaskExists(int taskId)
        {
            try
            {
                return ctx.UserTasks.Any(x => x.Task_ID == taskId);
            }
            catch (Exception ex)
            {
                throw new RepoUserTasksEFException("TaskExists", ex);
            }
        }
    }
}
