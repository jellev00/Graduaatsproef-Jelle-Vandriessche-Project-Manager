using ProjectManager.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Interfaces
{
    public interface IUserTasksRepo
    {
        Task<List<UserTasks>> GetAllTasks(int userId);
        void AddTask(UserTasks userTask);
        void DeleteTask(int taskId);
        bool TaskExists(int taskId);
    }
}
