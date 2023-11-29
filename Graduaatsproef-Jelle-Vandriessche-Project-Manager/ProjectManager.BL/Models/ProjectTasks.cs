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
        public ProjectTasks(int projectId, string taskDescription)
        {
            _projectId = projectId;
            _taskDescription = taskDescription;
        }

        public ProjectTasks(int taskId, int projectId, string taskDescription)
        {
            _taskId = taskId;
            _projectId = projectId;
            _taskDescription = taskDescription;
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
    }
}
