using ProjectManager.BL.Models;
using ProjectManager.EF.Models;
using ProjectManager.EF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Mapper
{
    public class MapProjectTasksEF
    {
        public static ProjectTasks MapToDomain(ProjectTasksEF db)
        {
            try
            {
                return new ProjectTasks(db.Project_Task_ID, db.Project_ID, db.Task_Name, db.Task_Description, db.Color);
            } catch (Exception ex)
            {
                throw new MapEFException("MapProjectTasksEF - MapToDomain", ex);
            }
        }

        public static ProjectTasksEF MapToDB(ProjectTasks pT)
        {
            try
            {
                return new ProjectTasksEF(pT.ProjectId, pT.TaskName, pT.TaskDescription, pT.Color);
            } catch (Exception ex)
            {
                throw new MapEFException("MapProjectTasksEF - MapToDB", ex);
            }
        }
    }
}
