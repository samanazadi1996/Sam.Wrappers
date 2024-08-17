
# Sam.Wrappers

[![](https://github.com/samanazadi1996/Sam.Wrappers/workflows/.NET/badge.svg)](https://github.com/samanazadi1996/Sam.Wrappers/actions)
[![NuGet](https://img.shields.io/nuget/vpre/Sam.Wrappers.svg)](https://www.nuget.org/packages/Sam.Wrappers)

This package contains classes and methods designed for managing operation results, errors, and paginated responses in .NET applications.

## Installation

To install the Sam.File Table Framework package, simply use the following command
```sh
dotnet add package Sam.Wrappers
```

## Features

- **[BaseResult](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/BaseResult.cs#L7-L37) and [BaseResult<T>](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/BaseResult.cs#L39-L62)**: 
  - Handle operation results with an indication of success or failure.
  - Provide support for single or multiple errors.
  - Allow chaining and adding errors post-creation.
  - Implicitly convert from error or list of errors to `BaseResult` for flexible error handling.

- **[PagedResponse<T>](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/PagedResponse.cs)**: 
  - Manage paginated data responses, encapsulating data along with pagination metadata like page number, total pages, and total items.
  - Includes static factory methods to quickly generate paginated results.

- **[Error](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/Error.cs) and [ErrorCode](https://github.com/samanazadi1996/Sam.Wrappers/blob/main/Source/Sam.Wrappers/ErrorCode.cs)**:
  - Define errors with an `ErrorCode` enum that covers standard HTTP status codes and custom application-specific errors.
  - Structure errors with optional descriptions and field names for context.

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
int pageSize = 2;
int totalCount = 3;

// Create a paginated response
var pagedResponse = PagedResponse<string>.Ok(data, pageNumber, pageSize, totalCount);
```

### Error and ErrorCode

Use `Error` and `ErrorCode` to manage errors and refer to specific predefined error codes.

```csharp
using Sam.Wrappers;

var error = new Error(ErrorCode.NotFound, "Item not found", "ItemId");
```

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
