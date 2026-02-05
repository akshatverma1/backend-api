using Microsoft.AspNetCore.Mvc;

namespace StudioBackendAPI.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "Backend running 🚀" });
        }
    }
}
