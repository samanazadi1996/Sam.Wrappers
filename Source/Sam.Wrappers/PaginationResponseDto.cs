using System.Collections.Generic;

namespace Sam.Wrappers
{
    public class PaginationResponseDto<T>
    {
        public PaginationResponseDto(List<T> data, int count, int pageNumber, int pageSize)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Count = count;
        }
        public List<T> Data { get; set; }
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}