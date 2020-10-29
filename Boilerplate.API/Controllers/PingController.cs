using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<bool> Get()
        {
            return Ok(true);
        }
    }
}