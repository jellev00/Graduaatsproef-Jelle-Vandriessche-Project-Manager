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
        List<ProjectCalendar> GetAllCalendars(int projectId);
        ProjectCalendar AddCalendar(ProjectCalendar projectCalendar);
    }
}
