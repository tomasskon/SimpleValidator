using System;

namespace LibraryImplementation.Domain.Exceptions
{
    public class InvalidUserPasswordException : Exception
    {
        public InvalidUserPasswordException()
        {
        }

        public InvalidUserPasswordException(string message)
            : base(message)
        {
        }

        public InvalidUserPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}