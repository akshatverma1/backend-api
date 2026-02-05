using System.Net;
using System.Net.Mail;

namespace StudioBackendAPI.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendAsync(string subject, string body)
        {
            var host = _config["EmailSettings:Host"];
            var port = int.Parse(_config["EmailSettings:Port"]);
            var sender = _config["EmailSettings:SenderEmail"];
            var password = _config["EmailSettings:Password"];
            var admin = _config["EmailSettings:AdminEmail"];

            using var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(sender, password),
                EnableSsl = true
            };

            var mail = new MailMessage(sender, admin, subject, body)
            {
                IsBodyHtml = true
            };

            await client.SendMailAsync(mail);
        }
    }
}
