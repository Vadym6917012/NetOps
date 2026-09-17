using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace NetOps.Api.Exceptions
{
    public sealed class GlobalExceptionHandler
        : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService;

        public GlobalExceptionHandler(
            IProblemDetailsService problemDetailsService)
        {
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if ( exception is not ValidationException validationException )
                return false;

            httpContext.Response.StatusCode =
                StatusCodes.Status400BadRequest;

            var errors = validationException.Errors
                .GroupBy(error => error.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group
                    .Select(error => error.ErrorMessage)
                        .ToArray());

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation failed",
                Detail = "One or more validation errors occurred." 
            };

            problemDetails.Extensions ["errors"] = errors;

            return await _problemDetailsService.TryWriteAsync(
                new ProblemDetailsContext 
                { 
                    HttpContext = httpContext,
                    ProblemDetails = problemDetails
                });
        }
    }
}
