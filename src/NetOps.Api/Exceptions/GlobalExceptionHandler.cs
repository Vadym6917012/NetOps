using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetOps.Application.Exceptions;
using NetOps.Domain.Exceptions;

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
            if ( exception is NotFoundException notFoundException )
            {
                httpContext.Response.StatusCode =
                    StatusCodes.Status404NotFound;

                var notFoundProblemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Resource not found",
                    Detail = notFoundException.Message
                };

                return await _problemDetailsService.TryWriteAsync(
                    new ProblemDetailsContext
                    {
                        HttpContext = httpContext,
                        ProblemDetails = notFoundProblemDetails
                    });
            }

            if ( exception is BusinessRuleException businessRuleException )
            {
                httpContext.Response.StatusCode =
                    StatusCodes.Status409Conflict;

                var businessProblemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status409Conflict,
                    Title = "Business rule violation.",
                    Detail = businessRuleException.Message
                };

                return await _problemDetailsService.TryWriteAsync(
                    new ProblemDetailsContext
                    {
                        HttpContext = httpContext,
                        ProblemDetails = businessProblemDetails
                    });
            }

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
