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
    public class MapUserEF
    {
        public static User MapToDomain(UserEF db)
        {
            try
            {
                return new User(db.User_ID, db.First_Name, db.Last_Name, db.Email, db.Password);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapUser - MapToDomain", ex);
            }
        }

        public static UserEF MapToDB(User u)
        {
            try
            {
                return new UserEF(u.First_Name, u.Last_Name, u.Email, u.Password);
            }
            catch (Exception ex)
            {
                throw new MapEFException("MapUser - MapToDB", ex);
            }
        }
    }
}
