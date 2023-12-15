using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Exceptions
{
    public class RepoProjectsEFException : Exception
    {
        public RepoProjectsEFException(string? message) : base(message)
        {
        }

        public RepoProjectsEFException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
