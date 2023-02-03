using AnimalChipizationAndMonitoringSystem.WebApi.Middleware;

namespace AnimalChipizationAndMonitoringSystem.WebApi.Extensions
{
    public static class CustomExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
