using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.Models;

namespace ProjectManager.BL.Interfaces
{
    public interface IUserRepo
    {
        User GetUser(int userId);
        User GetUserByName(string userName);
        void AddUser(User user);
        void DeleteUser(string userName);
        bool UserExists(string userName);
    }
}
