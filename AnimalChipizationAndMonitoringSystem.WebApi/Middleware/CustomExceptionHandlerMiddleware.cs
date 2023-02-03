using AnimalChipizationAndMonitoringSystem.Application.Common.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace AnimalChipizationAndMonitoringSystem.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        } 

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            string response = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    response = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case UnauthorizedActionException unauthorizedActionException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ForbiddenActionException forbiddenActionException:
                    code = HttpStatusCode.Forbidden;
                    break;
                case ConflictActionException conflictActionException:
                    code = HttpStatusCode.Conflict;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            if (response == string.Empty)
                response = JsonSerializer.Serialize(new { error = exception.Message });
            return context.Response.WriteAsync(response);
        }
    }
}
