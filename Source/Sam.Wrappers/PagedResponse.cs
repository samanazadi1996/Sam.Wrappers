using System;
using System.Collections.Generic;
using System.Linq;

namespace Sam.Wrappers
{
    public class PagedResponse<T> : BaseResult<List<T>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public static PagedResponse<T> Ok(PaginationResponseDto<T> model)
        {
            return new PagedResponse<T>
            {
                Success = true,
                Data = model.Data,
                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                TotalItems = model.Count,
                TotalPages = (int)Math.Ceiling(model.Count / (double)model.PageSize)
            };
        }
        public static PagedResponse<T> Ok(List<T> data, int pageNumber, int pageSize, int totalCount)
        {
            return new PagedResponse<T>
            {
                Success = true,
                Data = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };
        }

        public new static PagedResponse<T> Failure(Error error)
            => new PagedResponse<T> { Success = false, Errors = new List<Error>() { error } };

        public new static PagedResponse<T> Failure(IEnumerable<Error> errors)
            => new PagedResponse<T> { Success = false, Errors = errors.ToList() };

        public static implicit operator PagedResponse<T>(PaginationResponseDto<T> model)
            => Ok(model);

        public static implicit operator PagedResponse<T>(Error error)
            => new PagedResponse<T> { Success = false, Errors = new List<Error>() { error } };

        public static implicit operator PagedResponse<T>(List<Error> errors)
            => new PagedResponse<T> { Success = false, Errors = errors };
    }
}