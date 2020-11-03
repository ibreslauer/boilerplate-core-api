using AutoMapper.QueryableExtensions;
using Boilerplate.Common.Models;
using Boilerplate.Data.Models;
using Boilerplate.Data.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Data.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public Task<User> GetUserAsync(string username, string passwordHash)
        {
            return DataContext.User
                .FirstOrDefaultAsync(u => u.Username == username
                    && u.PasswordHash == passwordHash
                    && !u.IsDeleted);
        }

        public Task<UserModel> GetUserByIdAsync(long id)
        {
            return DataContext.User
                .ProjectTo<UserModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public IQueryable<UserModel> GetAll()
        {
            return DataContext.User
                .ProjectTo<UserModel>(Mapper.ConfigurationProvider);
        }
    }
}
