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

        public bool UserExists(string userName)
        {
            try
            {
                return ctx.Users.Any(x => x.Name == userName);
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("UserExists", ex);
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

        public User GetUserByName(string userName)
        {
            try
            {
                return MapUserEF.MapToDomain(ctx.Users.Where(x => x.Name == userName).AsNoTracking().FirstOrDefault());
            } catch (Exception ex)
            {
                throw new RepoUserEFException("GetUserByName", ex);
            }
        }

        public void DeleteUser(string userName)
        {
            try
            {
                var userToDelete = ctx.Users.SingleOrDefault(x => x.Name == userName);

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
