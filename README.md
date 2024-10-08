
# Sam.Wrappers

[![](https://github.com/samanazadi1996/Sam.Wrappers/workflows/.NET/badge.svg)](https://github.com/samanazadi1996/Sam.Wrappers/actions)
[![NuGet](https://img.shields.io/nuget/vpre/Sam.Wrappers.svg)](https://www.nuget.org/packages/Sam.Wrappers)

This package contains classes and methods designed for managing operation results, errors, and paginated responses in .NET applications.

## Installation

To install the Sam.Wrappers package, simply use the following command
```sh
dotnet add package Sam.Wrappers
```

## Features

- **[BaseResult](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/BaseResult.cs#L7-L37) and [BaseResult&#60;T>](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/BaseResult.cs#L39-L62)**
  - Handle operation results with an indication of success or failure.
  - Provide support for single or multiple errors.
  - Allow chaining and adding errors post-creation.
  - Implicitly convert from error or list of errors to `BaseResult` for flexible error handling.

- **[PagedResponse&#60;T>](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/PagedResponse.cs)**
  - Manage paginated data responses, encapsulating data along with pagination metadata like page number, total pages, and total items.
  - Includes static factory methods to quickly generate paginated results.

- **[Error](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/Error.cs) and [ErrorCode](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/ErrorCode.cs)**
  - Define errors with an `ErrorCode` enum that covers standard HTTP status codes and custom application-specific errors.
  - Structure errors with optional descriptions and field names for context.

- **[AppException](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/AppException.cs)**
  - Offers a variety of static methods in `AppException` class to throw exceptions based on different conditions such as null values, empty collections, out-of-range values, etc.
  - Easily integrates with ASP.NET Core applications through middleware for global exception handling.

## Usage

### BaseResult

The `BaseResult` and `BaseResult<T>` classes are used to handle operation results, allowing you to check for success or failure and manage errors.

```csharp
using Sam.Wrappers;

// Create a successful result
var successResult = BaseResult.Ok();

// Create a failed result with an error
var error = new Error(ErrorCode.BadRequest, "Invalid data");
var failureResult = BaseResult.Failure(error);
```

### PagedResponse

The `PagedResponse<T>` class is used to manage paginated responses in APIs and systems that require pagination.

```csharp
using Sam.Wrappers;
using System.Collections.Generic;

// Sample data
var data = new List<string> { "Item1", "Item2", "Item3" };
int pageNumber = 1;
int pageSize = 3;
int totalCount = 3;

// Create a paginated response
var pagedResponse = PagedResponse<string>.Ok(data, totalCount, pageNumber, pageSize);
```

### Error and ErrorCode

Use `Error` and `ErrorCode` to manage errors and refer to specific predefined error codes.

```csharp
using Sam.Wrappers;

var error = new Error(ErrorCode.NotFound, "Item not found", "ItemId");
```

### AppException
The `AppException` class and related middleware provide a streamlined way to handle application-specific exceptions and errors.


#### Example: Throwing Exceptions

```c#
using Sam.Wrappers;

// Throw a simple exception
AppException.Throw(ErrorCode.BadRequest, "Invalid request data");

// Throw an exception if a value is null
AppException.ThrowIfNull(someValue, ErrorCode.NotFound, "Value cannot be null", "SomeField");

// Throw an exception if a collection is empty
AppException.ThrowIfEmpty(someCollection, ErrorCode.NoContent, "Collection is empty", "SomeCollection");
```
#### Integrating with ASP.NET Core
```c#
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

// In Startup.cs or Program.cs
public void ConfigureServices(IServiceCollection services)
{
    services.ConfigureAppExceptionHandling(options =>
    {
        options.StatusCode = 500; // Default status code for unhandled exceptions
    });
}

public void Configure(IApplicationBuilder app)
{
    app.UseAppExceptionHandling();
    app.UseRouting();
    // other middleware
}
```
This setup ensures that all `AppException` exceptions are caught and returned as structured JSON responses with appropriate HTTP status codes.

## Contributing

Contributions are welcome! If you’d like to contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch (git checkout -b feature/YourFeature).
3. Make your changes and commit them (git commit -am 'Add new feature').
4. Push to the branch (git push origin feature/YourFeature).
5. Open a Pull Request.
   
If you encounter any issues or have suggestions, feel free to open an issue in the repository.

## License

This project is licensed under the [MIT License](LICENSE).
