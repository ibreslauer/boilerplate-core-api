using Codes = Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Boilerplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IMapper Mapper { get; private set; }

        public BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected ActionResult InternalServerError(object value)
        {
            return StatusCode(Codes.Status500InternalServerError, value);
        }
    }
}
