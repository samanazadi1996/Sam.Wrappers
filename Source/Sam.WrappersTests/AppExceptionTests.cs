using Sam.Wrappers;

namespace Sam.WrappersTests;

public class AppExceptionTests
{
    [Fact]
    public void Throw_ShouldThrowAppException_WithCorrectErrorCodeAndDescription()
    {
        // Arrange
        var expectedErrorCode = ErrorCode.NotFound;
        var expectedDescription = "Test error message";

        // Act & Assert
        var exception = Assert.Throws<AppException>(() =>
            AppException.Throw(expectedErrorCode, expectedDescription));

        // Assert
        Assert.Equal(expectedErrorCode, exception.Error.ErrorCode);
        Assert.Equal(expectedDescription, exception.Error.Description);
    }

    [Fact]
    public void ThrowIfNull_ShouldThrowAppException_WhenObjectIsNull()
    {
        // Arrange
        object? nullObject = null;
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        var exception = Assert.Throws<AppException>(() =>
            AppException.ThrowIfNull(nullObject, errorCode, "Object is null"));

        // Assert
        Assert.Equal(errorCode, exception.Error.ErrorCode);
        Assert.Equal("Object is null", exception.Error.Description);
    }

    [Fact]
    public void ThrowIfNull_ShouldNotThrow_WhenObjectIsNotNull()
    {
        // Arrange
        var notNullObject = new object();
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        AppException.ThrowIfNull(notNullObject, errorCode); // Should not throw
    }

    [Fact]
    public void ThrowIfFalse_ShouldThrowAppException_WhenConditionIsFalse()
    {
        // Arrange
        bool condition = false;
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        var exception = Assert.Throws<AppException>(() =>
            AppException.ThrowIfFalse(condition, errorCode, "Condition is false"));

        // Assert
        Assert.Equal(errorCode, exception.Error.ErrorCode);
        Assert.Equal("Condition is false", exception.Error.Description);
    }

    [Fact]
    public void ThrowIfFalse_ShouldNotThrow_WhenConditionIsTrue()
    {
        // Arrange
        bool condition = true;
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        AppException.ThrowIfFalse(condition, errorCode); // Should not throw
    }

    [Fact]
    public void ThrowIfTrue_ShouldThrowAppException_WhenConditionIsTrue()
    {
        // Arrange
        bool condition = true;
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        var exception = Assert.Throws<AppException>(() =>
            AppException.ThrowIfTrue(condition, errorCode, "Condition is true"));

        // Assert
        Assert.Equal(errorCode, exception.Error.ErrorCode);
        Assert.Equal("Condition is true", exception.Error.Description);
    }

    [Fact]
    public void ThrowIfTrue_ShouldNotThrow_WhenConditionIsFalse()
    {
        // Arrange
        bool condition = false;
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        AppException.ThrowIfTrue(condition, errorCode); // Should not throw
    }

    [Fact]
    public void ThrowIfEmpty_ShouldThrowAppException_WhenCollectionIsEmpty()
    {
        // Arrange
        var emptyList = new List<int>();
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        var exception = Assert.Throws<AppException>(() =>
            AppException.ThrowIfEmpty(emptyList, errorCode, "Collection is empty"));

        // Assert
        Assert.Equal(errorCode, exception.Error.ErrorCode);
        Assert.Equal("Collection is empty", exception.Error.Description);
    }

    [Fact]
    public void ThrowIfEmpty_ShouldNotThrow_WhenCollectionIsNotEmpty()
    {
        // Arrange
        var nonEmptyList = new List<int> { 1, 2, 3 };
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        AppException.ThrowIfEmpty(nonEmptyList, errorCode); // Should not throw
    }

    [Fact]
    public void ThrowIfEmpty_ShouldThrowAppException_WhenStringIsNullOrWhiteSpace()
    {
        // Arrange
        string? emptyString = " ";
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        var exception = Assert.Throws<AppException>(() =>
            AppException.ThrowIfEmpty(emptyString, errorCode, "String is empty"));

        // Assert
        Assert.Equal(errorCode, exception.Error.ErrorCode);
        Assert.Equal("String is empty", exception.Error.Description);
    }

    [Fact]
    public void ThrowIfEmpty_ShouldNotThrow_WhenStringIsNotEmpty()
    {
        // Arrange
        string nonEmptyString = "NotEmpty";
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        AppException.ThrowIfEmpty(nonEmptyString, errorCode); // Should not throw
    }

    [Fact]
    public void ThrowIfOutOfRange_ShouldThrowAppException_WhenValueIsOutOfRange()
    {
        // Arrange
        int value = 10;
        int min = 0;
        int max = 5;
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        var exception = Assert.Throws<AppException>(() =>
            AppException.ThrowIfOutOfRange(value, min, max, errorCode, "Value is out of range"));

        // Assert
        Assert.Equal(errorCode, exception.Error.ErrorCode);
        Assert.Equal("Value is out of range", exception.Error.Description);
    }

    [Fact]
    public void ThrowIfOutOfRange_ShouldNotThrow_WhenValueIsWithinRange()
    {
        // Arrange
        int value = 3;
        int min = 0;
        int max = 5;
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        AppException.ThrowIfOutOfRange(value, min, max, errorCode); // Should not throw
    }

    [Fact]
    public void ThrowIfAny_ShouldThrowAppException_WhenAnyElementMatchesPredicate()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4 };
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        var exception = Assert.Throws<AppException>(() =>
            AppException.ThrowIfAny(x => x > 3, list, errorCode, "Found element greater than 3"));

        // Assert
        Assert.Equal(errorCode, exception.Error.ErrorCode);
        Assert.Equal("Found element greater than 3", exception.Error.Description);
    }

    [Fact]
    public void ThrowIfAny_ShouldNotThrow_WhenNoElementMatchesPredicate()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4 };
        var errorCode = ErrorCode.FieldDataInvalid;

        // Act & Assert
        AppException.ThrowIfAny(x => x > 5, list, errorCode); // Should not throw
    }
}
