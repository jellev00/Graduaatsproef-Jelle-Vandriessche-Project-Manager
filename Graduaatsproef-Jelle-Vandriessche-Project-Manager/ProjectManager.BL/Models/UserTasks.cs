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
        public UserTasks(int userId, string taskName, string taskDescription, string color)
        {
            _userId = userId;
            _taskName = taskName;
            _taskDescription = taskDescription;
            _color = color;
        }

        public UserTasks(int taskId, int userId, string taskName, string taskDescription, string color)
        {
            _taskId = taskId;
            _userId = userId;
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

        private int _userId;
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
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
