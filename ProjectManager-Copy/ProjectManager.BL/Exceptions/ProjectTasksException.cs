using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Exceptions
{
    public class ProjectTasksException : Exception
    {
        public ProjectTasksException(string? message) : base(message)
        {
        }

        public ProjectTasksException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
