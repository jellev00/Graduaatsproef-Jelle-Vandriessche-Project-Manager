using ProjectManager.BL.Models;
using ProjectManager.EF.Exceptions;
using ProjectManager.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Mapper
{
    public class MapProjectCalendar
    {
        public static ProjectCalendar MapToDomain(ProjectCalendarEF db)
        {
            try
            {
                return new ProjectCalendar(db.Project_CalendarID, db.Project_ID, db.Name, db.Description, db.Date);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapProjectCalendar - MapToDomain", ex);
            }
        }

        public static ProjectCalendarEF MapToDB(ProjectCalendar pC)
        {
            try
            {
                return new ProjectCalendarEF(pC.ProjectId, pC.Name, pC.Description, pC.Date);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapProjectCalendar - MapToDB", ex);
            }
        }
    }
}
