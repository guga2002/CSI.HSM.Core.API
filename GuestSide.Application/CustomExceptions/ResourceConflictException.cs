using System.Runtime.Serialization;

namespace GuestSide.Application.CustomExceptions
{
    public class ResourceConflictException : Exception
    {
        public ResourceConflictException()
        {
        }

        public ResourceConflictException(string? message) : base(message)
        {
        }

        public ResourceConflictException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ResourceConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
