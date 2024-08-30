using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sam.Wrappers.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly AppExceptionHandlerOptions _option;
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next, AppExceptionHandlerOptions options)
        {
            _next = next;
            _option = options;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException applicationException)
            {
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = _option.StatusCode ?? (int)applicationException.Error.ErrorCode;

                var responseModel = BaseResult.Failure(applicationException.Error);

                var result = JsonSerializer.Serialize(responseModel, _option.JsonSerializerOptions);

                await context.Response.WriteAsync(result);
            }
        }
    }
}