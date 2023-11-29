using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.Models;

namespace ProjectManager.BL.Interfaces
{
    public interface IProjectRepo
    {
        //List<Project> GetAllProjects(int userId);
        Task<List<Project>> GetAllProjects(int userId);
        void AddProject(Project project);
        void DeleteProject(int projectID);
        bool ProjectExists(int projectID);
    }
}
