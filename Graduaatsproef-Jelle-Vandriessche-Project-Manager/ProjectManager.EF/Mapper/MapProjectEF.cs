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
    public class MapProjectEF
    {
        public static Project MapToDomain(ProjectsEF db)
        {
            try
            {
                return new Project(db.Project_ID, db.User_ID, db.Name, db.Description);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapProject - MapToDomain", ex);
            }
        }

        public static ProjectsEF MapToDB(Project p)
        {
            try
            {
                return new ProjectsEF(p.ProjectId, p.UserId, p.Name, p.Description);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapProject - MapToDB", ex);
            }
        }
    }
}
