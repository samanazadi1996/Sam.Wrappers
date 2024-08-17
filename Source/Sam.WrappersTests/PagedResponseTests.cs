using Sam.Wrappers;

namespace Sam.WrappersTests;

public class PagedResponseTests
{
    [Fact]
    public void PagedResponse_Ok_WithPaginationResponseDto_ShouldReturnSuccessTrue()
    {
        // Arrange
        var data = new List<string> { "Item1", "Item2" };
        var model = new PaginationResponseDto<string>(data, 5, 1, 2);

        // Act
        var result = PagedResponse<string>.Ok(model);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(data, result.Data);
        Assert.Equal(1, result.PageNumber);
        Assert.Equal(2, result.PageSize);
        Assert.Equal(5, result.TotalItems);
        Assert.Equal(3, result.TotalPages); // 5 items / 2 per page = 2.5 -> 3 pages
    }

    [Fact]
    public void PagedResponse_Ok_WithManualParameters_ShouldReturnSuccessTrue()
    {
        // Arrange
        var data = new List<string> { "Item1", "Item2" };
        int pageNumber = 1;
        int pageSize = 2;
        int totalCount = 5;

        // Act
        var result = PagedResponse<string>.Ok(data, pageNumber, pageSize, totalCount);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(data, result.Data);
        Assert.Equal(pageNumber, result.PageNumber);
        Assert.Equal(pageSize, result.PageSize);
        Assert.Equal(totalCount, result.TotalItems);
        Assert.Equal(3, result.TotalPages); // 5 items / 2 per page = 2.5 -> 3 pages
    }

    [Fact]
    public void PagedResponse_Failure_WithError_ShouldReturnSuccessFalseAndContainError()
    {
        // Arrange
        var error = new Error(ErrorCode.BadRequest, "Bad request");

        // Act
        var result = PagedResponse<string>.Failure(error);

        // Assert
        Assert.False(result.Success);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Fact]
    public void PagedResponse_Failure_WithErrors_ShouldReturnSuccessFalseAndContainErrors()
    {
        // Arrange
        var errors = new List<Error>
        {
            new Error(ErrorCode.BadRequest, "Bad request"),
            new Error(ErrorCode.NotFound, "Not found")
        };

        // Act
        var result = PagedResponse<string>.Failure(errors);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact]
    public void ImplicitConversion_FromPaginationResponseDto_ShouldCreateSuccessResult()
    {
        // Arrange
        var data = new List<string> { "Item1", "Item2" };
        var model = new PaginationResponseDto<string>(data, 5, 1, 2);

        // Act
        PagedResponse<string> result = model;

        // Assert
        Assert.True(result.Success);
        Assert.Equal(data, result.Data);
        Assert.Equal(1, result.PageNumber);
        Assert.Equal(2, result.PageSize);
        Assert.Equal(5, result.TotalItems);
        Assert.Equal(3, result.TotalPages); // 5 items / 2 per page = 2.5 -> 3 pages
    }

    [Fact]
    public void ImplicitConversion_FromError_ShouldCreateFailureResult()
    {
        // Arrange
        var error = new Error(ErrorCode.BadRequest, "Bad request");

        // Act
        PagedResponse<string> result = error;

        // Assert
        Assert.False(result.Success);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Fact]
    public void ImplicitConversion_FromErrorList_ShouldCreateFailureResult()
    {
        // Arrange
        var errors = new List<Error>
        {
            new Error(ErrorCode.BadRequest, "Bad request"),
            new Error(ErrorCode.NotFound, "Not found")
        };

        // Act
        PagedResponse<string> result = errors;

        // Assert
        Assert.False(result.Success);
        Assert.Equal(2, result.Errors.Count);
    }
}