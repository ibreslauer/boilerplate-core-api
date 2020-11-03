using Boilerplate.Common.Models;
using Boilerplate.Data.Models;
using System;
using System.Threading.Tasks;

namespace Boilerplate.Data.Services.Contracts
{
    public interface ITokenService
    {
        Task<UserToken> GetActiveTokenAsync(string accessToken, bool useCache = false);
        Task<UserToken> GetActiveTokenByUserAndDeviceAsync(long userId, string deviceId);
        Task<bool> SaveAsync(User user, string accessToken, DateTime? expiryDate, string deviceId);
        Task<TokenModel> DeactivateTokenAsync(string accessToken);
    }
}
