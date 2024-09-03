using Sam.Wrappers;

namespace Sam.WrappersTests;

public class BaseResultTDataTests
{
    [Fact]
    public void BaseResultTData_Ok_ShouldReturnSuccessTrueWithData()
    {
        // Arrange
        var data = "TestData";

        // Act
        var result = BaseResult<string>.Ok(data);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(data, result.Data);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void BaseResultTData_Failure_ShouldReturnSuccessFalse()
    {
        // Act
        var result = BaseResult<string>.Failure();

        // Assert
        Assert.False(result.Success);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void BaseResultTData_Failure_WithError_ShouldReturnSuccessFalseAndContainError()
    {
        // Arrange
        var error = new Error(ErrorCode.BadRequest, "Bad request");

        // Act
        var result = BaseResult<string>.Failure(error);

        // Assert
        Assert.False(result.Success);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Fact]
    public void BaseResultTData_Failure_WithErrors_ShouldReturnSuccessFalseAndContainErrors()
    {
        // Arrange
        var errors = new List<Error>
        {
            new(ErrorCode.BadRequest, "Bad request"),
            new(ErrorCode.NotFound, "Not found")
        };

        // Act
        var result = BaseResult<string>.Failure(errors);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact]
    public void ImplicitConversion_FromData_ShouldCreateSuccessResult()
    {
        // Arrange
        var data = "TestData";

        // Act
        BaseResult<string> result = data;

        // Assert
        Assert.True(result.Success);
        Assert.Equal(data, result.Data);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void ImplicitConversion_FromError_ShouldCreateFailureResult()
    {
        // Arrange
        var error = new Error(ErrorCode.BadRequest, "Bad request");

        // Act
        BaseResult<string> result = error;

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
            new(ErrorCode.BadRequest, "Bad request"),
            new(ErrorCode.NotFound, "Not found")
        };

        // Act
        BaseResult<string> result = errors;

        // Assert
        Assert.False(result.Success);
        Assert.Equal(2, result.Errors.Count);
    }
}