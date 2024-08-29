using Sam.Wrappers;

namespace Sam.WrappersTests;

public class AppExceptionTests
{
    [Fact]
    public void Throw_ShouldThrowApplicationException_WithCorrectErrorCodeAndMessage()
    {
        // Arrange
        var expectedErrorCode = ErrorCode.NotFound;
        var expectedMessage = "Test error message";

        // Act & Assert
        var exception = Assert.Throws<AppException.ApplicationException>(() =>
            AppException.Throw(expectedErrorCode, expectedMessage));

        // Assert
        Assert.Equal(expectedErrorCode, exception.Error.ErrorCode);
        Assert.Equal(expectedMessage, exception.Error.Description);
    }
}