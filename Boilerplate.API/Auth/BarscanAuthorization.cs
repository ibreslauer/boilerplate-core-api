using Boilerplate.Data.Services;
using Boilerplate.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Boilerplate.API.Auth
{
    public class BarscanAuthorization : IAsyncAuthorizationFilter
    {
        private readonly TokenService _tokenService;
        public BarscanAuthorization(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.GetBearerToken();

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // check if the token exists in the DB and is marked active
            var dbToken = await _tokenService.GetActiveTokenAsync(token);
            if (dbToken == null || !dbToken.IsActive)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
