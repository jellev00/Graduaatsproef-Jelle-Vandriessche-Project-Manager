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
                if (_repo.UserExistsEmail(user.Email))
                {
                    throw new UserException("AddUser - User Already exists!");
                }
                _repo.AddUser(user);
            } catch (Exception ex)
            {
                throw new UserException("AddUser", ex);
            }
        }

        public User GetUser(int userId)
        {
            try
            {
                if (!_repo.UserExistsID(userId))
                {
                    throw new UserException("GetUser - User doesn't exist!");
                }
                return _repo.GetUser(userId);
            }
            catch (Exception ex)
            {
                throw new UserException("GetUser", ex);
            }
        }

        public User GetUserByEmail(string Email)
        {
            try
            {
                if (!_repo.UserExistsEmail(Email))
                {
                    throw new UserException("GetUserByEmail - User doesn't exist!");
                }
                return _repo.GetUserByEmail(Email);
            } catch (Exception ex)
            {
                throw new UserException("GetUserByEmail", ex);
            }
        }

        public void DeleteUser(string Email)
        {
            try
            {
                if (!_repo.UserExistsEmail(Email))
                {
                    throw new UserException("DeleteUser - User doesn't exist!");
                }
                _repo.DeleteUser(Email);
            } catch (Exception ex)
            {
                throw new UserException("DeleteUser", ex);
            }
        }

        public bool UserExistsEmail(string Email)
        {
            try
            {
                return _repo.UserExistsEmail(Email);
            }
            catch (Exception ex)
            {
                throw new UserException("UserExistsEmail", ex);
            }
        }

        public bool UserExistsID(int userId)
        {
            try
            {
                return _repo.UserExistsID(userId);
            }
            catch (Exception ex)
            {
                throw new UserException("UserExistsID", ex);
            }
        }
    }
}
