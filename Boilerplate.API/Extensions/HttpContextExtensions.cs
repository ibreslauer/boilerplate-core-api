using Boilerplate.Common.Constants;
using Boilerplate.Common.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Boilerplate.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetBearerToken(this HttpContext ctx)
        {
            if (ctx.Request.Headers.TryGetValue("Authorization", out var tokenValue))
            {
                return tokenValue.Count > 0 && tokenValue[0].StartsWith("Bearer ") ?
                    tokenValue[0].Replace("Bearer ", "") :
                    null;
            }
            return null;
        }

        public static string GetDeviceId(this HttpContext ctx)
        {
            return GetHeaderValue(ctx, AppConstants.HEADER_DEVICE_ID);
        }

        public static async Task Write400Async(this HttpContext context, string message)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError(message)));
        }

        public static async Task Write401Async(this HttpContext context, string message)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError(message)));
        }

        private static string GetHeaderValue(HttpContext ctx, string key)
        {
            try
            {
                return ctx.Request.Headers[key][0];
            }
            catch
            {
                return null;
            }
        }
    }
}
