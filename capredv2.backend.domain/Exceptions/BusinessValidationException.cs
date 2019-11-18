using System;

namespace capredv2.backend.domain.Exceptions
{
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException() {}

        public BusinessValidationException(string message) : base(message) {}

        public BusinessValidationException(string message, Exception inner) : base(message, inner) {}
    }
}
