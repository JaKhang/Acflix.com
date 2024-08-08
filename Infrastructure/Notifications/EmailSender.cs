namespace Infrastructure.Notifications;

public class EmailSender: IEmailSender
{
    public Task SendVerify(string email, string code)
    {
        throw new NotImplementedException();
    }

    public Task SendResetPassword(string email, string code)
    {
        throw new NotImplementedException();
    }
}