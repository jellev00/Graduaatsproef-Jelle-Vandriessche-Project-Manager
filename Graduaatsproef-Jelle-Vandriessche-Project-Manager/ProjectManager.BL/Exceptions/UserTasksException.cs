using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Exceptions
{
    public class UserTasksException : Exception
    {
        public UserTasksException(string? message) : base(message)
        {
        }

        public UserTasksException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
