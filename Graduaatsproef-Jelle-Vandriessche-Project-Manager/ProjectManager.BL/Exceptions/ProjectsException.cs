using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BL.Exceptions
{
    public class ProjectsException : Exception
    {
        public ProjectsException(string? message) : base(message)
        {
        }

        public ProjectsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
