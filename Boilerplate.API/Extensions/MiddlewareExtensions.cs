using Boilerplate.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Boilerplate.API.Extensions
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Requires an X-Device-Id header on every request
        /// </summary>
        public static IApplicationBuilder UseMandatoryDeviceId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BoilerplateDeviceIdMiddleware>();
        }

        /// <summary>
        /// Validates Barscan's persisted tokens
        /// </summary>
        public static IApplicationBuilder UseBoilerplateAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BoilerplateAuthMiddleware>();
        }
    }
}
