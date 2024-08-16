using Application.Mappers;
using Application.Models.User;
using Domain.User.Entities;
using Domain.User.ObjectValue;
using Domain.User.Repositories;
using Infrastructure.Authentication;
using Infrastructure.Notifications;

namespace Application.Commands;

public class AuthenticationCommand(IUserRepository userRepository, IEmailSender emailSender, ICodeGenerator codeGenerator, IJwtProvider jwtProvider, UserMapper userMapper) : IAuthenticationCommands
{

    public async Task Verify(string email, string code)
    {
        var user = await userRepository.FindByEmailAsync(email);
        if (user is null) throw new UserNotFoundException();
        user.Verify(code);
        user = await userRepository.SaveAsync(user);
    }

    public Task ResetPassword(ResetPasswordRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task RequestVerifyCode(string email)
    {
        //tao code
        var code = codeGenerator.Generate();
        var user = await userRepository.FindByEmailAsync(email);
        if (user is null) throw new UserNotFoundException("Not found user with email " + email);
        user.AddCode(code, 5, TokenType.VERIFY);

        //luu code
        user = await userRepository.SaveAsync(user);

        var task = emailSender.SendVerify(email, code);
    }

    public async Task RequestResetPasswordCode(string email)
    {
        var user = await userRepository.FindByEmailAsync(email);
        if (user is null) throw new UserNotFoundException("Not found user with email " + email);
        var code = codeGenerator.Generate();
        user.AddCode(code, 5, TokenType.RESSET);
        user = await userRepository.SaveAsync(user);
        var task = emailSender.SendResetPassword(email, code);


    }

    public async Task<Guid> Register(RegisterRequest register)
    {

        if (await userRepository.ExistByEmail(register.Email))
            throw new UserAlreadyExistException("User Already exist with email " + register.Email);
        var user = userMapper.Map(register);
        user = await userRepository.SaveAsync(user);
        return user.Id.Value;
    }

    public async Task<AuthResponse> Authenticate(AuthRequest request)
    {
        var user = await userRepository.FindByEmailAsync(request.Email);
        if (user is null)
            throw new UserAlreadyExistException("User not found with email " + request.Email);
        var token = jwtProvider.Generate(user);
        var response = new AuthResponse(user.RefreshToken, token);
        return response;
    }
}

public class UserAlreadyExistException(string userAlreadyExistWithEmail) : SystemException(userAlreadyExistWithEmail);

public class UserNotFoundException: Exception
{
    public UserNotFoundException()
    {
    }

    public UserNotFoundException(string? message) : base(message)
    {
    }
}