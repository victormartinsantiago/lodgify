namespace VacationRental.Contact.Api.Middlewares
{
    using System;
    using System.Threading.Tasks;
    using Domain.Common.Exceptions;
    using Domain.Common.Extensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _environment;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory,
            IHostingEnvironment environment)
        {
            _environment = environment;
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var details = GetProblemDetails(ex);

                _logger.LogError(ex, $"An error occurred while processing request '{httpContext.TraceIdentifier}'");

                await httpContext.Response.WriteErrorResponseAsync(details);
            }
        }

        private ProblemDetails GetProblemDetails(Exception exception)
        {
            var statusCode = 500;
            var title = "Internal Server Error";

            if (exception is BaseException)
            {
                var baseException = exception as BaseException;
                title = baseException.Title;
                statusCode = baseException.StatusCode;
            }

            return new ProblemDetails()
            {
                Status = statusCode,
                Title = title,
                Detail = !_environment.IsProduction() ? exception.Message : null
            };
        }
    }
}
