using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.Models;

namespace ProjectManager.BL.Interfaces
{
    public interface IUserRepo
    {
        // POST
        void AddUser(User user);
        void AddTaskToUser(int userId, UserTasks userTask);
        void AddProjectToUser(int userId, Project project);

        // GET
        User GetUserById(int userId);
        User GetUserByEmail(string email);

        // DELETE
        void DeleteUser(string email);
        void DeleteTask(int taskId);
        void DeleteProject(int projectId);

        // UPDATE
        void UpdateTaskStatus(int taskId, bool taskStatus);

        // EXISTS
        bool UserExistsEmail(string email);
        bool UserExistsId(int userId);
        bool UserTaskExistsId(int taskId);
        bool ProjectExistsId(int projectId);

    }
}
