
using System;

namespace Sam.Wrappers
{
    public class AppException
    {
        public static void Throw(ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            throw new ApplicationException(new Error(errorCode, description, fieldName));
        }
        public class ApplicationException : Exception
        {
            public readonly Error Error;
            public ApplicationException(Error error) => Error = error;
        }
    }
}