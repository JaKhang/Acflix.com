using Domain.User.Entities;

namespace Infrastructure.Notifications;

public interface IEmailSender
{
    Task SendVerify(string email, Code verificationCode);
    Task SendResetPassword(string email, Code resetPass);
}