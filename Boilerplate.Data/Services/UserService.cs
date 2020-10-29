using AutoMapper.QueryableExtensions;
using Boilerplate.Common.Models;
using Boilerplate.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Data.Services
{
    public class UserService : BaseService
    {
        public UserService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<User> GetUserAsync(string username, string passwordHash)
        {
            var user = await DataContext.User
                .FirstOrDefaultAsync(u => u.Username == username
                    && u.PasswordHash == passwordHash
                    && !u.IsDeleted);
            return user;
        }

        public async Task<UserModel> GetUserByIdAsync(long id)
        {
            return await DataContext.User
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
