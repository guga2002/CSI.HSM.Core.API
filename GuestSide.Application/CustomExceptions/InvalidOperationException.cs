using System.Runtime.Serialization;

namespace GuestSide.Application.CustomExceptions
{
    public class InvalidOperationException : Exception
    {
        public InvalidOperationException()
        {
        }

        public InvalidOperationException(string? message) : base(message)
        {
        }

        public InvalidOperationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
