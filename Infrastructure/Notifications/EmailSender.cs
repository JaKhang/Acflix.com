using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Domain.User.Entities; 

namespace Infrastructure.Notifications
{
    public class EmailSender : IEmailSender
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _senderEmail = "123@gmail.com";   // Email gửi
        private readonly string _senderName = "AC Flix";          // Tên mail muốn gửi
        private readonly string _senderPassword = "";             // Mật khẩu của email gửi

        public async Task SendVerify(string email, Code verificationCode)
        {
            var subject = "Verify your email";
            var body = $"This is the code to verify your email: {verificationCode.Value}";
            await SendEmailAsync(email, subject, body);
        }

        public async Task SendResetPassword(string email, Code resetPass)
        {
            var subject = "Reset your password";
            var body = $"This is your new password: {resetPass.Value}";
            await SendEmailAsync(email, subject, body);
        }

        private async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            var message = new MailMessage();
            message.From = new MailAddress(_senderEmail, _senderName);
            message.To.Add(new MailAddress(recipientEmail));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = false;

            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
                smtpClient.EnableSsl = true;

                try
                {
                    await smtpClient.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send email: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
