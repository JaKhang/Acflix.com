using Application.Models.User;

namespace Application.Commands;

public class AuthenticationCommand : IAuthenticationCommands
{
    public Task Verify(string email, string code)
    {
        throw new NotImplementedException();
    }

    public Task ResetPassword(string email, ResetPasswordRequest request)
    {
        throw new NotImplementedException();
    }

    public Task RequestVerifyCode(string email)
    {
        throw new NotImplementedException();
    }

    public Task RequestResetPasswordCode(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Register(RegisterRequest register)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponse> Authenticate(AuthRequest request)
    {
        throw new NotImplementedException();
    }
}