namespace Infrastructure.Notifications;

public interface IEmailSender
{
    Task SendVerify(string email, string code);
    Task SendResetPassword(string email, string code);
}