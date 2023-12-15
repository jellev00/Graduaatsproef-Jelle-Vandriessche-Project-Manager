using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Exceptions
{
    public class RepoProjectCalendarEFException : Exception
    {
        public RepoProjectCalendarEFException(string? message) : base(message)
        {
        }

        public RepoProjectCalendarEFException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
