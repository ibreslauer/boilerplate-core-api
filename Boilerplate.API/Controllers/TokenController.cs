using AutoMapper;
using Boilerplate.API.Auth;
using Boilerplate.API.Extensions;
using Boilerplate.Common.Constants;
using Boilerplate.Common.Models;
using Boilerplate.Common.Exceptions;
using Boilerplate.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text;
using Boilerplate.Data.Models;

namespace Boilerplate.API.Controllers
{
    public class TokenController : BaseController
    {
        private readonly AuthOptions _authOptions;

        public TokenController(IOptions<AuthOptions> authOptionsAccessor, IMapper mapper)
            : base(mapper)
        {
            _authOptions = authOptionsAccessor.Value;
        }

        [HttpPost]
        public async Task<ActionResult> IssueToken(UserModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiError("Error issuing token.", "Invalid user object."));
            try
            {
                var deviceId = HttpContext.GetDeviceId();

                var validUser = await new UserService(HttpContext.RequestServices)
                    .GetUserAsync(user.Username, user.PasswordHash);
                if (validUser == null)
                {
                    return NotFound(new ApiError("Invalid username/password"));
                }

                var tokenService = new TokenService(HttpContext.RequestServices);

                // check if an active token already exists for the user
                var existingToken = await tokenService.GetActiveTokenByUserAndDeviceAsync(validUser.Id, deviceId);
                if (existingToken != null)
                {
                    // Edge-case: token already exists for the given user-device pair. Deactivate existing token, issue a new one.
                    _ = await tokenService.DeactivateTokenAsync(existingToken.Token);
                }

                var token = GenerateToken(validUser);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                var insertSuccess = await tokenService.SaveAsync(
                    validUser,
                    tokenString,
                    token.ValidTo.DbSafeValue(),
                    deviceId);

                return Ok(new AuthResult
                {
                    User = Mapper.Map<UserModel>(validUser),
                    AccessToken = tokenString,
                    Expiration = token.ValidTo.DbSafeValue(),
                    Success = insertSuccess
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(new ApiError("Error issuing token.", ex.Message));
            }
        }

        [HttpPut]
        [Route("deactivate")]
        public async Task<ActionResult> DeactivateToken(TokenModel token)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiError("Provided token is invalid."));
            try
            {
                var tokenUpdate = await new TokenService(HttpContext.RequestServices)
                    .DeactivateTokenAsync(token.Token);
                return Ok(tokenUpdate);
            }
            catch (EntityNotFoundException nfEx)
            {
                return NotFound(new ApiError("Token not found.", nfEx.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiError("Error deactivating token.", ex.Message));
            }
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            var authClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(AppConstants.USER_ID_CLAIM, user.Id.ToString()),
                // add more user claims as necessary
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                expires: _authOptions.ExpiresInMinutes > 0 ?
                    DateTime.Now.AddMinutes(_authOptions.ExpiresInMinutes) :
                    (DateTime?)null,
                claims: authClaims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SecureKey)),
                    SecurityAlgorithms.HmacSha256Signature)
                );
        }
    }
}