﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace LibraryImplementation.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message)
            : base(message)
        {
        }

        public UserNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}