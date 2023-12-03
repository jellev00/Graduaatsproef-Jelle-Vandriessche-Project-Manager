using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Models;
using ProjectManager.EF.Exceptions;
using ProjectManager.EF.Mapper;

namespace ProjectManager.EF.Repositories
{
    public class RepoUserEF : IUserRepo
    {
        private ContextEF ctx;

        public RepoUserEF(string connectionString)
        {
            this.ctx = new ContextEF(connectionString);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AddUser(User user)
        {
            try
            {
                ctx.Add(MapUserEF.MapToDB(user));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("AddUser", ex);
            }
        }

        public bool UserExistsEmail(string Email)
        {
            try
            {
                return ctx.Users.Any(x => x.Email == Email);
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("UserExistsEmail", ex);
            }
        }

        public bool UserExistsID(int userId)
        {
            try
            {
                return ctx.Users.Any(x => x.User_ID == userId);
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("UserExistsID", ex);
            }
        }

        public User GetUser(int userId)
        {
            try
            {
                return MapUserEF.MapToDomain(ctx.Users.Where(x => x.User_ID == userId).AsNoTracking().FirstOrDefault());
            } catch (Exception ex)
            {
                throw new RepoUserEFException("GetUser", ex);
            }
        }

        public User GetUserByEmail(string Email)
        {
            try
            {
                return MapUserEF.MapToDomain(ctx.Users.Where(x => x.Email == Email).AsNoTracking().FirstOrDefault());
            } catch (Exception ex)
            {
                throw new RepoUserEFException("GetUserByEmail", ex);
            }
        }

        public void DeleteUser(string Email)
        {
            try
            {
                var userToDelete = ctx.Users.SingleOrDefault(x => x.Email == Email);

                if (userToDelete != null)
                {
                    ctx.Users.Remove(userToDelete);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("DeleteUser", ex);
            }
        }
    }
}
