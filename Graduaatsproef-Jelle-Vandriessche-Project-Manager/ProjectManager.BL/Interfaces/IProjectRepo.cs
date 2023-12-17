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
        // POST
        void AddTaskToProject(int projectId, ProjectTasks projectTask);

        // GET
        Project GetProjectById(int projectId);

        // DELETE
        void DeleteProjectTask(int projectTaskId);

        // Exists
        bool ProjectTasksExistsId(int taskId);
    }
}
