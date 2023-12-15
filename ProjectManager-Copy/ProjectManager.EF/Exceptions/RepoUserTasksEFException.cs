using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Exceptions
{
    public class RepoUserTasksEFException : Exception
    {
        public RepoUserTasksEFException(string? message) : base(message)
        {
        }

        public RepoUserTasksEFException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
