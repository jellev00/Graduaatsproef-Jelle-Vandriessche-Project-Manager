using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Exceptions
{
    public class RepoProjectTasksEFException : Exception
    {
        public RepoProjectTasksEFException(string? message) : base(message)
        {
        }

        public RepoProjectTasksEFException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
