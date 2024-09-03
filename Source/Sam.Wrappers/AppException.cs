
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sam.Wrappers
{
    public class AppException : Exception
    {
        public readonly Error Error;

        public AppException(Error error)
        {
            Error = error;
        }

        public static void Throw(ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            throw new AppException(new Error(errorCode, description, fieldName));
        }

        public static void ThrowIfNull<T>(T value, ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            if (value == null)
                throw new AppException(new Error(errorCode, description, fieldName));
        }

        public static void ThrowIfFalse(bool condition, ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            if (!condition)
                throw new AppException(new Error(errorCode, description, fieldName));
        }

        public static void ThrowIfTrue(bool condition, ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            if (condition)
                throw new AppException(new Error(errorCode, description, fieldName));
        }

        public static void ThrowIfEmpty<T>(ICollection<T> collection, ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            if (!collection.Any())
                throw new AppException(new Error(errorCode, description, fieldName));
        }

        public static void ThrowIfEmpty(string? str, ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new AppException(new Error(errorCode, description, fieldName));
        }

        public static void ThrowIfOutOfRange<T>(T value, T min, T max, ErrorCode errorCode, string? description = null, string? fieldName = null) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                throw new AppException(new Error(errorCode, description, fieldName));
        }

        public static void ThrowIfAny<T>(Func<T, bool> predicate, IEnumerable<T> collection, ErrorCode errorCode, string? description = null, string? fieldName = null)
        {
            if (collection.Any(predicate))
                throw new AppException(new Error(errorCode, description, fieldName));
        }

    }
}