using System;
using System.Runtime.Serialization;

namespace DBCourseWork.DB.UserSystem.Exceptions
{
    [Serializable]
    internal class AddUserException : Exception
    {
        public AddUserException()
        {
        }

        public AddUserException(string message) : base(message)
        {
        }

        public AddUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}