using AutoMapper;
using Boilerplate.API.Extensions;
using Boilerplate.Common.Models;
using Boilerplate.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Boilerplate.API.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(IMapper mapper) : base(mapper)
        { }

        [HttpGet]
        public async Task<ActionResult<PagedList<UserModel>>> GetUsers([FromQuery] PagingQueryParams pagingParams)
        {
            try
            {
                var usersQuery = new UserService(HttpContext.RequestServices)
                    .GetAll();

                PagedList<UserModel> pagedList = await usersQuery.ToPagedListAsync(pagingParams);
                return Ok(pagedList);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiError("Error retrieving users.", ex.Message));
            }
        }

        [HttpGet]
        [Route("{userId:long}")]
        public async Task<ActionResult<UserModel>> GetUserById(long userId)
        {
            try
            {
                var user = await new UserService(HttpContext.RequestServices)
                    .GetUserByIdAsync(userId);

                if (user == null) NotFound(new ApiError($"Couldn't find user with Id {userId}"));

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiError("Error retrieving user.", ex.Message));
            }
        }
    }
}