using ProjectManager.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Models
{
    public class User
    {
        public User(string firstName, string lastName, string email, string password)
        {
            _first_name = firstName;
            _last_name = lastName;
            _email = email;
            _password = password;
        }

        public User(int userId, string firstName, string lastName, string email, string password, List<UserTasks> userTasks, List<Project> projects)
        {
            _userId = userId;
            _first_name = firstName;
            _last_name = lastName;
            _email = email;
            _password = password;
            _userTasks = userTasks;
            _projects = projects;
        }

        public User()
        {
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
                if (value <= 0)
                {
                    throw new UserException("ID is invalid!");
                } else
                {
                    _userId = value;
                }
            }
        }

        private string _first_name;
        public string First_Name
        {
            get
            {
                return _first_name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new UserException("First Name is invalid!");
                } else
                {
                    _first_name = value;
                }
            }
        }

        private string _last_name;
        public string Last_Name
        {
            get
            {
                return _last_name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new UserException("Last Name is invalid!");
                }
                else
                {
                    _last_name = value;
                }
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if ((string.IsNullOrWhiteSpace(value)) || (!value.Contains('@')))
                {
                    throw new UserException("Email is invalid!");
                } else
                {
                    _email = value;
                }
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value.Length < 8 || !ContainsUpperCaseLetter(value) || !ContainsDigit(value))
                {
                    throw new UserException("Invalid password. Password must be at least 8 characters long, contain at least 1 uppercase letter, and at least 1 number.");
                } else
                {
                    _password = value;
                }
            }
        }

        private List<UserTasks> _userTasks;
        public List<UserTasks> UserTasks
        {
            get
            {
                return _userTasks;
            }
            set
            {
                if (value == null)
                {
                    throw new UserException("UserTasks can't be null!");
                }
                else
                {
                    _userTasks = value;
                }
            }
        }

        private List<Project> _projects;
        public List<Project> Projects
        {
            get
            {
                return _projects;
            }
            set
            {
                if (value == null)
                {
                    throw new UserException("Projects can't be null!");
                }
                else
                {
                    _projects = value;
                }
            }
        }

        private bool ContainsUpperCaseLetter(string input)
        {
            return input.Any(char.IsUpper);
        }

        private bool ContainsDigit(string input)
        {
            return input.Any(char.IsDigit);
        }
    }
}
