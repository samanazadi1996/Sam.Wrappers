
using System;

namespace Sam.Wrappers
{
    public class AppException : Exception
    {
        public readonly Error Error;
        public AppException(Error error) => Error = error;

        public static void Throw(ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            throw new AppException(new Error(errorCode, description, fieldName));
        }
    }
}