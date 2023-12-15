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
    public class ProjectManager
    {
        private IProjectRepo _repo;

        public ProjectManager(IProjectRepo repo)
        {
            _repo = repo;
        }

        public List<Project> GetAllProjects(int userId)
        {
            try
            {
                return _repo.GetAllProjects(userId).Result;
            } catch (Exception ex)
            {
                throw new ProjectsException("GetAllProjects", ex);
            }
        }

        public void AddProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    throw new ProjectsException("AddProject");
                }
                _repo.AddProject(project);
            } catch (Exception ex)
            {
                throw new ProjectsException("AddProject", ex);
            }
        }

        public void DeleteProject(int projectID)
        {
            try
            {
                if (!_repo.ProjectExists(projectID))
                {
                    throw new ProjectsException("DeleteProject - Project doesn't exist!");
                }
                _repo.DeleteProject(projectID);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("DeleteProject", ex);
            }
        }

        public bool ProjectExists(int projectID)
        {
            try
            {
                return _repo.ProjectExists(projectID);
            }
            catch (Exception ex)
            {
                throw new ProjectsException("ProjectExists", ex);
            }
        }
    }
}
