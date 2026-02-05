using Microsoft.AspNetCore.Mvc;
using StudioBackendAPI.Data;
using StudioBackendAPI.Models;
using StudioBackendAPI.Services;

namespace StudioBackendAPI.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly EmailService _email;

        public ContactController(ApplicationDbContext db, EmailService email)
        {
            _db = db;
            _email = email;
        }

        [HttpPost]
        public async Task<IActionResult> Send(ContactMessage message)
        {
            _db.ContactMessages.Add(message);
            await _db.SaveChangesAsync();

            await _email.SendAsync(
                "New Contact Form Submission",
                $"<h3>{message.Name}</h3><p>{message.Message}</p>"
            );

            return Ok(new { success = true });
        }
    }
}
