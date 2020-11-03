using Boilerplate.Common.Models;
using Boilerplate.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Data.Services.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string username, string passwordHash);
        Task<UserModel> GetUserByIdAsync(long id);
        IQueryable<UserModel> GetAll();
    }
}
