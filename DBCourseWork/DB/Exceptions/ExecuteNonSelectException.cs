﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.DB.Exceptions
{
    class ExecuteNonSelectException : Exception
    {
        public ExecuteNonSelectException(string message = "") : base(message) { }
    }
}
