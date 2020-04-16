using Microsoft.AspNetCore.Builder;
using Mnemosyne.Web.Middleware;

namespace Mnemosyne.Web.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}