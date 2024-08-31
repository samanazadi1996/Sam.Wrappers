using Microsoft.AspNetCore.Builder;
using Sam.Wrappers.Middlewares;
using System;
using System.Text.Json;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ConfigureAppExceptionHandling(this IServiceCollection services, Action<AppExceptionHandlerOptions>? configureOptions = null)
        {
            var appExceptionHandlerOptions = new AppExceptionHandlerOptions();

            configureOptions?.Invoke(appExceptionHandlerOptions);

            services.AddSingleton(appExceptionHandlerOptions);

            return services;
        }

        public static IApplicationBuilder UseAppExceptionHandling(this IApplicationBuilder app)
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