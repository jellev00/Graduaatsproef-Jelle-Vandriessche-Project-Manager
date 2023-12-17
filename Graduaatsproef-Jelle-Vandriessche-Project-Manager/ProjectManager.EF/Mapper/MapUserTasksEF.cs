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
                User user = new User(db.User.User_ID, db.User.First_Name, db.User.Last_Name, db.User.Email, db.User.Password);

                return new UserTasks(db.Task_ID, user, db.Task_Name, db.Task_Description, db.Color, db.Date);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapUserTasks - MapToDomain", ex);
            }
        }

        public static UserTasksEF MapToDB(UserTasks uT, ContextEF ctx)
        {
            try
            {
                UserEF user = ctx.Users.Find(uT.User.UserId);

                if (user == null)
                {
                    // Handle the case where the user is not found in the database
                    throw new MapEFException($"User with ID {uT.User.UserId} not found.");
                }

                return new UserTasksEF(user, uT.TaskName, uT.TaskDescription, uT.Color, uT.Date);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapUserTasks - MapToDB", ex);
            }
        }
    }
}
