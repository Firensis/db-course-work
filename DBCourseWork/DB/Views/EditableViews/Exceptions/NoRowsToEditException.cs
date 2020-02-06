using System;
using System.Runtime.Serialization;

namespace DBCourseWork.DB.Views.EditableViews.Exceptions
{
    [Serializable]
    internal class NoRowsToEditException : Exception
    {
        public NoRowsToEditException()
        {
        }

        public NoRowsToEditException(string message) : base(message)
        {
        }

        public NoRowsToEditException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoRowsToEditException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}