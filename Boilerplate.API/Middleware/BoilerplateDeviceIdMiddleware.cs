using Boilerplate.API.Extensions;
using Boilerplate.Common.Constants;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Boilerplate.API.Middleware
{
    public class BoilerplateDeviceIdMiddleware
    {
        private readonly RequestDelegate _next;
        public BoilerplateDeviceIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var hasDeviceIdHeader = context.GetDeviceId() != null;

            if (hasDeviceIdHeader)
            {
                await _next.Invoke(context);
                return;
            }

            await context.Write400Async($"{AppConstants.HEADER_DEVICE_ID} header not specified");
        }
    }
}
