using System;

namespace LibraryImplementation.Domain.Exceptions
{
    public class InvalidUserPhoneNumberException : Exception
    {
        public InvalidUserPhoneNumberException()
        {
        }

        public InvalidUserPhoneNumberException(string message)
            : base(message)
        {
        }

        public InvalidUserPhoneNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}