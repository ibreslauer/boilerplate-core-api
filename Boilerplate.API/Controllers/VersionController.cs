using Boilerplate.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace Boilerplate.API.Controllers
{
    [ApiController]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        [Route("api/internal/version")]
        public ActionResult<ApiVersion> Get()
        {
            try
            {
                var assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                var version = Assembly.GetEntryAssembly().GetName().Version.ToString();
                var references = Assembly.GetEntryAssembly().GetReferencedAssemblies()
                    .Select(a => $"{a.Name} (v{a.Version})")
                    .OrderBy(x => x)
                    .ToList();

                return Ok(new ApiVersion
                {
                    AssemblyName = assemblyName,
                    Version = version,
                    References = references
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
