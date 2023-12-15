using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.Exceptions;

namespace ProjectManager.BL.Models
{
    public class UserTasks
    {
        public UserTasks(int taskId, User user, string taskName, string taskDescription, string color)
        {
            _taskId = taskId;
            _user = user;
            _taskName = taskName;
            _taskDescription = taskDescription;
            _color = color;
        }

        public UserTasks(User user, string taskName, string taskDescription, string color)
        {
            _taskName = taskName;
            _taskDescription = taskDescription;
            _color = color;
        }

        private int _taskId;
        public int TaskId
        {
            get 
            { 
                return _taskId; 
            }
            set
            {
                if (value <= 0)
                {
                    throw new UserTasksException("ID is invalid!");
                } else
                {
                    _taskId = value;
                }
            }
        }

        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                if (value == null)
                {
                    throw new UserTasksException("User is invalid!");
                }
                else
                {
                    _user = value;
                }
            }
        }

        private string _taskName;
        public string TaskName
        {
            get
            {
                return _taskName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new UserTasksException("TaskName is invalid!");
                }
                else
                {
                    _taskName = value;
                }
            }
        }

        private string _taskDescription;
        public string TaskDescription
        {
            get 
            { 
                return _taskDescription; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new UserTasksException("Description is invalid!");
                } else
                {
                    _taskDescription = value;
                }
            }
        }

        private string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new UserTasksException("Color is invalid!");
                }
                else
                {
                    _color = value;
                }
            }
        }
    }
}
