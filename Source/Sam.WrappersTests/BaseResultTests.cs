using Sam.Wrappers;

namespace Sam.WrappersTests;

public class BaseResultTests
{
    [Fact]
    public void BaseResult_Ok_ShouldReturnSuccessTrue()
    {
        // Act
        var result = BaseResult.Ok();

        // Assert
        Assert.True(result.Success);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void BaseResult_Failure_ShouldReturnSuccessFalse()
    {
        // Act
        var result = BaseResult.Failure();

        // Assert
        Assert.False(result.Success);
        Assert.Null(result.Errors);
    }

    [Fact]
    public void BaseResult_Failure_WithError_ShouldReturnSuccessFalseAndContainError()
    {
        // Arrange
        var error = new Error(ErrorCode.BadRequest, "Bad request");

        // Act
        var result = BaseResult.Failure(error);

        // Assert
        Assert.False(result.Success);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Fact]
    public void BaseResult_Failure_WithErrors_ShouldReturnSuccessFalseAndContainErrors()
    {
        // Arrange
        var errors = new List<Error>
            {
                new Error(ErrorCode.BadRequest, "Bad request"),
                new Error(ErrorCode.NotFound, "Not found")
            };

        // Act
        var result = BaseResult.Failure(errors);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact]
    public void BaseResult_AddError_ShouldAddErrorAndSetSuccessFalse()
    {
        // Arrange
        var result = BaseResult.Ok();
        var error = new Error(ErrorCode.BadRequest, "Bad request");

        // Act
        result.AddError(error);

        // Assert
        Assert.False(result.Success);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Fact]
    public void ImplicitConversion_FromError_ShouldCreateFailureResult()
    {
        // Arrange
        var error = new Error(ErrorCode.BadRequest, "Bad request");

        // Act
        BaseResult result = error;

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
        BaseResult result = errors;

        // Assert
        Assert.False(result.Success);
        Assert.Equal(2, result.Errors.Count);
    }
}