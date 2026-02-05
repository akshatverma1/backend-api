using Microsoft.AspNetCore.Mvc;
using StudioBackendAPI.Data;
using StudioBackendAPI.Models;
using StudioBackendAPI.Services;

namespace StudioBackendAPI.Controllers
{
    [ApiController]
    [Route("api/apply")]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly EmailService _email;

        public ApplicationController(ApplicationDbContext db, EmailService email)
        {
            _db = db;
            _email = email;
        }

        [HttpPost]
        public async Task<IActionResult> Apply(ProjectApplication app)
        {
            _db.ProjectApplications.Add(app);
            await _db.SaveChangesAsync();

            await _email.SendAsync(
                "New Project Application",
                $"<h3>{app.FullName}</h3><p>{app.ProjectTitle}</p>"
            );

            return Ok(new { success = true });
        }
    }
}
