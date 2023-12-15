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
        User GetUserByEmail(string Email);
        void AddUser(User user);
        void DeleteUser(string Email);
        bool UserExistsEmail(string Email);
        bool UserExistsID(int userId);

    }
}
