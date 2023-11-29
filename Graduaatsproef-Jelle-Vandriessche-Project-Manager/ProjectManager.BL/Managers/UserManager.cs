using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Models;
using ProjectManager.BL.Exceptions;

namespace ProjectManager.BL.Managers
{
    public class UserManager 
    {
        private IUserRepo _repo;

        public UserManager(IUserRepo repo)
        {
            _repo = repo;
        }

        public void AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new UserException("AddUser");
                }
                if (_repo.UserExists(user.Name))
                {
                    throw new UserException("AddUser - User Already exists!");
                }
                _repo.AddUser(user);
            } catch (Exception ex)
            {
                throw new UserException("AddUser", ex);
            }
        }

        public User GetUserByName(string userName)
        {
            try
            {
                if (!_repo.UserExists(userName))
                {
                    throw new UserException("GetUserByName - User doesn't exist!");
                }
                return _repo.GetUserByName(userName);
            } catch (Exception ex)
            {
                throw new UserException("GetUserByName", ex);
            }
        }

        public void DeleteUser(string userName)
        {
            try
            {
                if (!_repo.UserExists(userName))
                {
                    throw new UserException("DeleteUser - User doesn't exist!");
                }
                _repo.DeleteUser(userName);
            } catch (Exception ex)
            {
                throw new UserException("DeleteUser", ex);
            }
        }

        public bool UserExists(string userName)
        {
            try
            {
                return _repo.UserExists(userName);
            }
            catch (Exception ex)
            {
                throw new UserException("UserExists", ex);
            }
        }
    }
}
