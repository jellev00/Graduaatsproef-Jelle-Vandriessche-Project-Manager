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
    public class RepoProjectsEF : IProjectRepo
    {
        private ContextEF ctx;

        public RepoProjectsEF(string connectionString)
        {
            this.ctx = new ContextEF(connectionString);
        }

        private void SaveAndClear()
        {
            ctx.SaveChanges();
            ctx.ChangeTracker.Clear();
        }

        public void AddProject(Project project)
        {
            try
            {
                ctx.Add(MapProjectEF.MapToDB(project));
                ctx.SaveChanges();
            } catch (Exception ex)
            {
                throw new RepoProjectsEFException("AddProject", ex);
            }
        }

        public async Task<List<Project>> GetAllProjects(int userId)
        {
            try
            {
                var projects = await ctx.Projects
                    .Where(x => x.User_ID == userId)
                    .AsNoTracking()
                    .ToListAsync();

                return projects.Select(MapProjectEF.MapToDomain).ToList();
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("GetAllProjects", ex);
            }
        }

        public void DeleteProject(int projectID)
        {
            try
            {
                var projectToDelete = ctx.Projects.SingleOrDefault(x => x.Project_ID == projectID);

                if (projectToDelete != null)
                {
                    ctx.Projects.Remove(projectToDelete);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new RepoProjectsEFException("DeleteProject", ex);
            }
        }

        public bool ProjectExists(int projectID)
        {
            try
            {
                return ctx.Projects.Any(x => x.Project_ID == projectID);
            }
            catch (Exception ex)
            {
                throw new RepoUserEFException("ProjectExists", ex);
            }
        }
    }
}
