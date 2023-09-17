using Microsoft.AspNetCore.Builder;
using NorthwindBackend.Core.Extensions;

namespace NorthwindBackend.Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
