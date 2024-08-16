using Domain.User.Entities;

namespace Infrastructure.Notifications;

public interface IEmailSender
{
    Task SendVerify(string email, string verificationCode);
    Task SendResetPassword(string email, string resetPass);
}