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
        List<ProjectTasks> GetAllTasks(int projectId);
        ProjectTasks AddTask(ProjectTasks projectTask);
    }
}
