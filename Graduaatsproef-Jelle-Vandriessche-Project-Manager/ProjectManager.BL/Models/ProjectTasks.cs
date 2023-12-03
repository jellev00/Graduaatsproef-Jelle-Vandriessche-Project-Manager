using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BL.Exceptions;

namespace ProjectManager.BL.Models
{
    public class ProjectTasks
    {
        public ProjectTasks(int projectId, string taskName, string taskDescription, string color)
        {
            _projectId = projectId;
            _taskName = taskName;
            _taskDescription = taskDescription;
            _color = color;
        }

        public ProjectTasks(int taskId, int projectId, string taskName, string taskDescription, string color)
        {
            _taskId = taskId;
            _projectId = projectId;
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
                    throw new ProjectTasksException("ID is invalid!");
                }
            }
        }

        private int _projectId;
        public int ProjectId
        {
            get
            {
                return _projectId;
            }
            set
            {
                _projectId = value;
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
                    throw new ProjectTasksException("TaskName is invalid!");
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
                    throw new ProjectTasksException("Description is invalid!");
                }
                else
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
                    throw new ProjectTasksException("Color is invalid!");
                }
                else
                {
                    _color = value;
                }
            }
        }
    }
}
