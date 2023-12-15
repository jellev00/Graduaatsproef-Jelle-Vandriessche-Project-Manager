using ProjectManager.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Models
{
    public class Project
    {
        public Project(int projectId, User user, string name, string description, string color, List<ProjectTasks> projectTasks, List<ProjectCalendar> projectCalendars)
        {
            _projectId = projectId;
            _user = user;
            _name = name;
            _description = description;
            _color = color;
            _projectTasks = projectTasks;
            _projectCalendar = projectCalendars;
        }

        public Project(string name, string description, string color)
        {
            _name = name;
            _description = description;
            _color = color;
        }

        public Project(User user, string name, string description, string color)
        {
            _user = user;
            _name = name;
            _description = description;
            _color = color;
        }

        public Project(int projectId, User user, string name, string description, string color)
        {
            _projectId = projectId;
            _user = user;
            _name = name;
            _description = description;
            _color = color;
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
                if (value <= 0)
                {
                    throw new ProjectsException("ID is invalid!");
                } else
                {
                    _projectId = value;
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
                    throw new ProjectsException("User is invalid!");
                }
                else
                {
                    _user = value;
                }
            }
        }

        private string _name;
        public string Name
        {
            get 
            { 
                return _name; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ProjectsException("Name is invalid!");
                } else
                {
                    _name = value;
                }
            }
        }


        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ProjectsException("Description is invalid!");
                } else
                {
                    _description = value;
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
                    throw new ProjectsException("Color is invalid!");
                }
                else
                {
                    _color = value;
                }
            }
        }

        private List<ProjectTasks> _projectTasks;
        public List<ProjectTasks> ProjectTasks
        {
            get
            {
                return _projectTasks;
            }
            set
            {
                if (value == null)
                {
                    throw new ProjectsException("ProjectTasks can't be null!");
                }
                else
                {
                    _projectTasks = value;
                }
            }
        }

        private List<ProjectCalendar> _projectCalendar;
        public List<ProjectCalendar> ProjectCalendar
        {
            get
            {
                return _projectCalendar;
            }
            set
            {
                if (value == null)
                {
                    throw new ProjectsException("ProjectCalendar can't be null!");
                }
                else
                {
                    _projectCalendar = value;
                }
            }
        }
    }
}
