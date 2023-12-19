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
        public ProjectTasks(int taskId, Project project, string taskName, string taskDescription, string color, DateTime date, bool status)
        {
            _taskId = taskId;
            _project = project;
            _taskName = taskName;
            _taskDescription = taskDescription;
            _color = color;
            _date = date;
            _status = status;
        }

        public ProjectTasks(string taskName, string taskDescription, string color, DateTime date, bool status)
        {
            _taskName = taskName;
            _taskDescription = taskDescription;
            _color = color;
            Date = date;
            _status = status;
        }

        public ProjectTasks(Project project, string taskName, string taskDescription, string color, DateTime date, bool status)
        {
            _project = project;
            _taskName = taskName;
            _taskDescription = taskDescription;
            _color = color;
            Date = date;
            _status = status;
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
                    throw new ProjectTasksException("Project is invalid!");
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

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ProjectTasksException("Date is invalid!");
                }
                else
                {
                    _date = value;
                }
            }
        }

        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
