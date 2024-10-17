using System.Net;
using System.Net.Mail;

using API.MicroServices.Users.Src.Interfaces;

namespace API.MicroServices.Users.Src.Services
{
    public class EmailService : IEmailService
    {
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string smtpUsername;
        private readonly string smtpPassword;
        private readonly string fromEmail;
        private readonly string fromName;

        public EmailService(
            string smtpHost, string smtpPort, string smtpUsername,
            string smtpPassword, string fromEmail, string fromName)
        {
            this.smtpHost = smtpHost;
            this.smtpPort = int.Parse(smtpPort);
            this.smtpUsername = smtpUsername;
            this.smtpPassword = smtpPassword;
            this.fromEmail = fromEmail;
            this.fromName = fromName;
        }

        public async Task<bool> SendResetPasswordEmail(string email, string resetUrl)
        {
            try
            {
                var fromAddress = new MailAddress(fromEmail, fromName);
                var toAddress = new MailAddress(fromEmail);

                const string subject = "Password Reset Request";
                string body = $"<p>You can reset your password using the following link:</p><a href='{resetUrl}'>Reset Password</a>";

                var smtpClient = new SmtpClient(smtpHost)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    await smtpClient.SendMailAsync(message);
                }

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Email send failed: {ex.Message}");
                return false;
            }
        }
    }
}