﻿using ProjectManager.BL.Exceptions;
using ProjectManager.BL.Interfaces;
using ProjectManager.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Managers
{
    public class UserTasksManager
    {
        private IUserTasksRepo _repo;

        public UserTasksManager(IUserTasksRepo repo)
        {
            _repo = repo;
        }

        public void AddTask(UserTasks userTask)
        {
            try
            {
                if (userTask == null)
                {
                    throw new UserTasksException("AddTask");
                }
                _repo.AddTask(userTask);
            }
            catch (Exception ex)
            {
                throw new UserTasksException("AddTask", ex);
            }
        }

        public void DeleteTask(int userId)
        {
            try
            {
                if (!_repo.TaskExists(userId))
                {
                    throw new UserTasksException("DeleteTask - Task doesn't exist!");
                }
                _repo.DeleteTask(userId);
            }
            catch (Exception ex)
            {
                throw new UserTasksException("DeleteTask", ex);
            }
        }

        public List<UserTasks> GetAllTasks(int userId)
        {
            try
            {
                return _repo.GetAllTasks(userId).Result;
            }
            catch (Exception ex)
            {
                throw new UserTasksException("GetAllTasks", ex);
            }
        }

        public bool TaskExists(int userId)
        {
            try
            {
                return _repo.TaskExists(userId);
            }
            catch (Exception ex)
            {
                throw new UserTasksException("TaskExists", ex);
            }
        }
    }
}
