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
    public class MapUserTasksEF
    {
        public static UserTasks MapToDomain(UserTasksEF db)
        {
            try
            {
                return new UserTasks(db.Task_ID, db.User_ID, db.Task_Name, db.Task_Description, db.Color);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapUserTasks - MapToDomain", ex);
            }
        }

        public static UserTasksEF MapToDB(UserTasks uT)
        {
            try
            {
                return new UserTasksEF(uT.UserId, uT.TaskName, uT.TaskDescription, uT.Color);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapUserTasks - MapToDB", ex);
            }
        }
    }
}
