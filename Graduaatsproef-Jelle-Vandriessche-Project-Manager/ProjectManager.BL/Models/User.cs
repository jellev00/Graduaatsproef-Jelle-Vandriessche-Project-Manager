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
        public User(string name, string email, string password)
        {
            _name = name;
            _email = email;
            _password = password;
        }

        public User(int userId, string name, string email, string password)
        {
            _userId = userId;
            _name = name;
            _email = email;
            _password = password;
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
                    throw new UserException("Name is invalid!");
                } else
                {
                    _name = value;
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
