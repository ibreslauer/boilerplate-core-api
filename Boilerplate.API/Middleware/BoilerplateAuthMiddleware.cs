using Boilerplate.Data.Services;
using Boilerplate.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Boilerplate.API.Middleware
{
    public class BoilerplateAuthMiddleware
    {
        private readonly RequestDelegate _next;
        public BoilerplateAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var isAuthorizedEndpoint = context
                                   .GetEndpoint()?.Metadata
                                   .GetMetadata<AuthorizeAttribute>() != null;

            if (!isAuthorizedEndpoint)
            {
                await _next.Invoke(context);
                return;
            }

            var token = context.GetBearerToken();
            if (!string.IsNullOrWhiteSpace(token))
            {
                var dbToken = await new TokenService(context.RequestServices)
                    .GetActiveTokenAsync(token, true);
                if (dbToken != null && dbToken.IsActive)
                {
                    await _next.Invoke(context);
                    return;
                }
            }

            await context.Write401Async("Invalid token");
        }
    }
}
