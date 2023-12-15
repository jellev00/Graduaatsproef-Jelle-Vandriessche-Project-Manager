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
        public ProjectTasks(int taskId, Project project, string taskName, string taskDescription, string color)
        {
            _taskId = taskId;
            _project = project;
            _taskName = taskName;
            _taskDescription = taskDescription;
            _color = color;
        }

        public ProjectTasks(Project project, string taskName, string taskDescription, string color)
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
                    throw new ProjectTasksException("ID is invalid!");
                }
            }
        }

        private Project _project;
        public Project Project
        {
            get
            {
                return _project;
            }
            set
            {
                if (value == null)
                {
                    throw new ProjectCalendarException("Project is invalid!");
                }
                else
                {
                    _project = value;
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
