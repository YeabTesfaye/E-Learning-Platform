using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;

namespace api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Determine appropriate status code based on exception type
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound, // Custom exception handling
                            _ => StatusCodes.Status500InternalServerError // General server error
                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        // Send error details in response
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
