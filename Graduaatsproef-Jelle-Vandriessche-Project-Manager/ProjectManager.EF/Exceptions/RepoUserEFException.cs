using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Exceptions
{
    public class RepoUserEFException : Exception
    {
        public RepoUserEFException(string? message) : base(message)
        {
        }

        public RepoUserEFException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
