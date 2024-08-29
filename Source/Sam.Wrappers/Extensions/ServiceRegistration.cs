using Microsoft.AspNetCore.Builder;
using Sam.Wrappers.Infrastructure;
using System;
using System.Text.Json;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAppExceptionOptions(this IServiceCollection services, Action<AppExceptionHandlerOptions>? options = null)
        {
            var appExceptionHandlerOptions = new AppExceptionHandlerOptions();

            options?.Invoke(appExceptionHandlerOptions);

            services.AddSingleton(appExceptionHandlerOptions);

            return services;
        }
        public static IApplicationBuilder UseAppExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();

            return app;
        }
    }

    public class AppExceptionHandlerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; set; } = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        public int? StatusCode { get; set; }
    }
}