using Sam.Wrappers;

namespace Sam.WrappersTests;

public class ErrorTests
{
    [Fact]
    public void ErrorConstructor_WithAllParameters_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var errorCode = ErrorCode.BadRequest;
        var description = "This is a bad request.";
        var fieldName = "Field1";

        // Act
        var error = new Error(errorCode, description, fieldName);

        // Assert
        Assert.Equal(errorCode, error.ErrorCode);
        Assert.Equal(description, error.Description);
        Assert.Equal(fieldName, error.FieldName);
    }

    [Fact]
    public void ErrorConstructor_WithOnlyErrorCode_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var errorCode = ErrorCode.InternalServerError;

        // Act
        var error = new Error(errorCode);

        // Assert
        Assert.Equal(errorCode, error.ErrorCode);
        Assert.Null(error.Description);
        Assert.Null(error.FieldName);
    }

    [Fact]
    public void ErrorConstructor_WithErrorCodeAndDescription_ShouldInitializePropertiesCorrectly()
    {
        // Arrange
        var errorCode = ErrorCode.NotFound;
        var description = "Resource not found.";

        // Act
        var error = new Error(errorCode, description);

        // Assert
        Assert.Equal(errorCode, error.ErrorCode);
        Assert.Equal(description, error.Description);
        Assert.Null(error.FieldName);
    }

    [Fact]
    public void SetErrorCode_ShouldUpdateErrorCode()
    {
        // Arrange
        var error = new Error(ErrorCode.Ok);

        // Act
        error.ErrorCode = ErrorCode.Unauthorized;

        // Assert
        Assert.Equal(ErrorCode.Unauthorized, error.ErrorCode);
    }

    [Fact]
    public void SetDescription_ShouldUpdateDescription()
    {
        // Arrange
        var error = new Error(ErrorCode.Ok);
        var description = "New description.";

        // Act
        error.Description = description;

        // Assert
        Assert.Equal(description, error.Description);
    }

    [Fact]
    public void SetFieldName_ShouldUpdateFieldName()
    {
        // Arrange
        var error = new Error(ErrorCode.Ok);
        var fieldName = "NewField";

        // Act
        error.FieldName = fieldName;

        // Assert
        Assert.Equal(fieldName, error.FieldName);
    }
}