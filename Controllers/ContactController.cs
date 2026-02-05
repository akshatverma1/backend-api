using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // ✅ POST: Submit Contact Form
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

        // ✅ GET: Fetch All Contact Messages
        [HttpGet("all")]
        public async Task<IActionResult> GetAllContacts()
        {
            var messages = await _db.ContactMessages
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return Ok(messages);
        }
    }
}
