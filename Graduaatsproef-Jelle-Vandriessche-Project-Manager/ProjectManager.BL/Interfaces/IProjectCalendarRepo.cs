using ProjectManager.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Interfaces
{
    public interface IProjectCalendarRepo
    {
        Task<List<ProjectCalendar>> GetAllCalendars(int projectId);
        void AddCalendar(ProjectCalendar projectCalendar);
        void DeleteCalendar(int calendarID);
        bool CalendarExists(int calendarID);
    }
}
