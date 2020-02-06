using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Exceptions
{
    class AuthorizeException : Exception
    {
        public AuthorizeException() : base() { }
        public AuthorizeException(string message) : base(message) { }
    }
}
