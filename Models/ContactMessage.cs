using System.ComponentModel.DataAnnotations;

namespace StudioBackendAPI.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required] public string Subject { get; set; }

        [Required] public string Message { get; set; }
    }
}
