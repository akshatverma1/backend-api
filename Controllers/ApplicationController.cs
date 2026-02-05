using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // ✅ POST: Submit Application Form
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

        // ✅ GET: Fetch All Applications
        [HttpGet("all")]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await _db.ProjectApplications
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return Ok(applications);
        }
    }
}
