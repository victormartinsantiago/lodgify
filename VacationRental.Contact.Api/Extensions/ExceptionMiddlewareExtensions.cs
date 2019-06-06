namespace VacationRental.Contact.Api.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Middlewares;

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
