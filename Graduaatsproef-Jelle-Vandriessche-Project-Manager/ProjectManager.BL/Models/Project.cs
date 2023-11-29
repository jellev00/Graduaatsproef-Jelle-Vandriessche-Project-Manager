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
        public Project()
        {
        }

        public Project(int userId, string name, string description)
        {
            _userId = userId;
            _name = name;
            _description = description;
        }

        public Project(int projectId, int userId, string name, string description)
        {
            _projectId = projectId;
            _userId = userId;
            _name = name;
            _description = description;
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


    }
}
