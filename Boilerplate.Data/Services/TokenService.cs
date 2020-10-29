using Boilerplate.Common.Models;
using Boilerplate.Common.Exceptions;
using Boilerplate.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Data.Services
{
    public class TokenService : BaseService
    {
        public TokenService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<UserToken> GetActiveTokenAsync(string accessToken, bool useCache = false)
        {
            if (useCache && Cache.TryGetValue(accessToken, out UserToken token))
            {
                return token != null && token.IsActive ?
                    token :
                    null;
            }
            else
            {
                return await DataContext.UserToken
                    .Where(x => x.IsActive && x.Token == accessToken)
                    .AsTracking()
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<UserToken> GetActiveTokenByUserAndDeviceAsync(long userId, string deviceId)
        {
            return await DataContext.UserToken
                .Where(x => x.IsActive
                            && x.UserId == userId
                            && x.DeviceId == deviceId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync(User user, string accessToken, DateTime? expiryDate, string deviceId)
        {
            var token = new UserToken
            {
                UserId = user.Id,
                Token = accessToken,
                DeviceId = deviceId,
                IsActive = true,
                ExpiryDate = expiryDate
            };
            DataContext.UserToken.Add(token);

            Cache.Set(accessToken,
                token,
                absoluteExpiration: new DateTimeOffset(DateTime.Now.AddMinutes(1)));

            return await DataContext.SaveChangesAsync() > 0;
        }

        public async Task<TokenModel> DeactivateTokenAsync(string accessToken)
        {
            var token = await GetActiveTokenAsync(accessToken);
            _ = token ?? throw new EntityNotFoundException(accessToken);

            token.IsActive = false;
            token.ModifiedDate = DateTime.Now;

            var success = await DataContext.SaveChangesAsync() > 0;

            if (success) Cache.Remove(accessToken);

            return success ?
                Mapper.Map<TokenModel>(token) :
                null;
        }
    }
}
