using System;

namespace LibraryImplementation.Domain.Exceptions
{
    public class InvalidUserEmailException : Exception
    {
        public InvalidUserEmailException()
        {
        }

        public InvalidUserEmailException(string message)
            : base(message)
        {
        }

        public InvalidUserEmailException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}