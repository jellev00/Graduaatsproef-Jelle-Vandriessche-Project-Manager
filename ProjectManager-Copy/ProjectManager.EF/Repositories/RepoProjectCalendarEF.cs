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
    public class RepoProjectCalendarEF : IProjectCalendarRepo
    {
        private ContextEF ctx;

        public RepoProjectCalendarEF(string connectionString)
        {
            this.ctx = new ContextEF(connectionString);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AddCalendar(ProjectCalendar projectCalendar)
        {
            try
            {
                ctx.Add(MapProjectCalendar.MapToDB(projectCalendar));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepoProjectCalendarEFException("AddCalendar", ex);
            }
        }

        public async Task<List<ProjectCalendar>> GetAllCalendars(int projectId)
        {
            try
            {
                var calendar = await ctx.ProjectCalendar.Where(x => x.Project_ID == projectId).AsNoTracking().ToListAsync();

                return calendar.Select(MapProjectCalendar.MapToDomain).ToList();
            }
            catch (Exception ex)
            {
                throw new RepoProjectCalendarEFException("GetAllCalendars", ex);
            }
        }

        public void DeleteCalendar(int calendarID)
        {
            try
            {
                var projectCalendarToDelete = ctx.ProjectCalendar.SingleOrDefault(x => x.Project_CalendarID == calendarID);

                if (projectCalendarToDelete != null)
                {
                    ctx.ProjectCalendar.Remove(projectCalendarToDelete);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RepoProjectCalendarEFException("DeleteCalendar", ex);
            }
        }

        public bool CalendarExists(int calendarID)
        {
            try
            {
                return ctx.ProjectCalendar.Any(x => x.Project_CalendarID == calendarID);
            }
            catch (Exception ex)
            {
                throw new RepoProjectCalendarEFException("CalendarExists", ex);
            }
        }
    }
}
