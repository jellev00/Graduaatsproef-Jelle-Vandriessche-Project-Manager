using ProjectManager.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Interfaces
{
    public interface IProjectTasksRepo
    {
        Task<List<ProjectTasks>> GetAllTasks(int projectId);
        void AddTask(ProjectTasks projectTask);
        void DeleteTask(int taskId);
        bool TaskExists(int taskId);
    }
}
