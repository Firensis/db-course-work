using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Exceptions
{
    class ExecuteSelectException : Exception
    {
        public ExecuteSelectException(string message = "") : base(message) { }
    }
}
