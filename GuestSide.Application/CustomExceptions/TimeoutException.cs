using System.Runtime.Serialization;

namespace Core.Application.CustomExceptions
{
    public class TimeoutException : Exception
    {
        public TimeoutException()
        {
        }

        public TimeoutException(string? message) : base(message)
        {
        }

        public TimeoutException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
