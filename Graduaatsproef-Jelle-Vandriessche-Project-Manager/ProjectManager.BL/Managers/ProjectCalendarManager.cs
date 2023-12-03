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
    public class ProjectCalendarManager
    {
        private IProjectCalendarRepo _repo;
        public ProjectCalendarManager(IProjectCalendarRepo repo)
        {
            _repo = repo;
        }

        public List<ProjectCalendar> GetAllProjectCalendars(int projectId)
        {
            try
            {
                return _repo.GetAllCalendars(projectId).Result;
            }
            catch (Exception ex)
            {
                throw new ProjectCalendarException("GetAllProjectCalendars", ex);
            }
        }

        public void AddCalendar(ProjectCalendar projectCalendar)
        {
            try
            {
                if (projectCalendar == null)
                {
                    throw new ProjectCalendarException("AddCalendar");
                }
                _repo.AddCalendar(projectCalendar);
            }
            catch (Exception ex)
            {
                throw new ProjectCalendarException("AddCalendar", ex);
            }
        }
        public void DeleteCalendar(int calendarID)
        {
            try
            {
                if (!_repo.CalendarExists(calendarID))
                {
                    throw new ProjectCalendarException("DeleteCalendar - Project doesn't exist!");
                }
                _repo.DeleteCalendar(calendarID);
            }
            catch (Exception ex)
            {
                throw new ProjectCalendarException("DeleteCalendar", ex);
            }
        }
        public bool CalendarExists(int calendarID)
        {
            try
            {
                return _repo.CalendarExists(calendarID);
            }
            catch (Exception ex)
            {
                throw new ProjectCalendarException("CalendarExists", ex);
            }
        }
    }
}
