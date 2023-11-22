using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EF.Exceptions
{
    public class MapEFException : Exception
    {
        public MapEFException(string? message) : base(message)
        {
        }

        public MapEFException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
