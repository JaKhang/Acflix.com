using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Notifications;

public class EmailSender: IEmailSender
{
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly string _senderEmail = "123@gmail.com";   //  email gửi
    private readonly string _senderName = "AC Flix";    // Tên mail muốn gửi
    private readonly string _senderPassword = ""; //pass của email gửi 
    public async Task SendVerify(string email, string code )
    {
        code = code ?? GenerateRandomCode(6);
        var subject = "Verify your email";
        var body = $"This is the code to verify your email: {code}";
        await SendEmailAsync(email, subject, body);
    }

    public async Task SendResetPassword(string email, string code)
    {
        code = code ?? GenerateRandomCode(6);
        var subject = "Reset your password";
        var body = $"This is your new password: {code}";
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

    private static string GenerateRandomCode(int length)
    {
        const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-+=<>?";
        var random = new Random();
        return new string(Enumerable.Repeat(validChars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}