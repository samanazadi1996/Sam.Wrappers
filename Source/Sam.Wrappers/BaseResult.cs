using System.Collections.Generic;
using System.Linq;

namespace Sam.Wrappers
{

    public class BaseResult
    {
        public bool Success { get; set; }
        public List<Error>? Errors { get; set; }

        public static BaseResult Ok()
            => new BaseResult { Success = true };

        public static BaseResult Failure()
            => new BaseResult { Success = false };

        public static BaseResult Failure(Error error)
            => new BaseResult { Success = false, Errors = new List<Error> { error } };

        public static BaseResult Failure(IEnumerable<Error> errors)
            => new BaseResult { Success = false, Errors = errors.ToList() };

        public static implicit operator BaseResult(Error error)
            => new BaseResult { Success = false, Errors = new List<Error> { error } };

        public static implicit operator BaseResult(List<Error> errors)
            => new BaseResult { Success = false, Errors = errors };

        public BaseResult AddError(Error error)
        {
            Errors ??= new List<Error>();
            Errors.Add(error);
            Success = false;
            return this;
        }
    }

    public class BaseResult<TData> : BaseResult
    {
        public TData Data { get; set; }

        public static BaseResult<TData> Ok(TData data)
            => new BaseResult<TData> { Success = true, Data = data };
        public new static BaseResult<TData> Failure()
            => new BaseResult<TData> { Success = false };

        public new static BaseResult<TData> Failure(Error error)
            => new BaseResult<TData> { Success = false, Errors = new List<Error> { error } };

        public new static BaseResult<TData> Failure(IEnumerable<Error> errors)
            => new BaseResult<TData> { Success = false, Errors = errors.ToList() };

        public static implicit operator BaseResult<TData>(TData data)
            => new BaseResult<TData> { Success = true, Data = data };

        public static implicit operator BaseResult<TData>(Error error)
            => new BaseResult<TData> { Success = false, Errors = new List<Error> { error } };

        public static implicit operator BaseResult<TData>(List<Error> errors)
            => new BaseResult<TData> { Success = false, Errors = errors };
    }
}