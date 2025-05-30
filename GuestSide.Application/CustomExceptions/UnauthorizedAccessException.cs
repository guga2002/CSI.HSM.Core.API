﻿using System.Runtime.Serialization;

namespace Core.Application.CustomExceptions
{
    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException()
        {
        }

        public UnauthorizedAccessException(string? message) : base(message)
        {
        }

        public UnauthorizedAccessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
