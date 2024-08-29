using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1.ExceptionHandlers
{
    internal sealed class InvalidOperationExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<InvalidOperationExceptionHandler> _logger;

        public InvalidOperationExceptionHandler(ILogger<InvalidOperationExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not InvalidOperationException invalidOperationException)
            {
                return false;
            }

            _logger.LogError(
                invalidOperationException,
                "Exception occurred: {Message}",
                invalidOperationException.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = invalidOperationException.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}