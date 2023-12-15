using Microsoft.EntityFrameworkCore;
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
    public class MapProjectCalendarEF
    {
        public static ProjectCalendar MapToDomain(ProjectCalendarEF db)
        {
            try
            {
                User user = new User(db.Project.User.User_ID, db.Project.User.First_Name, db.Project.User.Last_Name, db.Project.User.Email, db.Project.User.Password);

                Project project = new Project(db.Project.Project_ID, user, db.Project.Name, db.Project.Description, db.Project.Color);

                return new ProjectCalendar(db.Project_CalendarID, project, db.Name, db.Description, db.Date);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapProjectCalendar - MapToDomain", ex);
            }
        }

        public static ProjectCalendarEF MapToDB(ProjectCalendar pC, ContextEF ctx)
        {
            try
            {
                ProjectsEF project = ctx.Projects.Where(x => x.Project_ID == pC.Project.ProjectId).Include(x => x.User).FirstOrDefault();

                return new ProjectCalendarEF(project, pC.Name, pC.Description, pC.Date);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapProjectCalendar - MapToDB", ex);
            }
        }
    }
}
