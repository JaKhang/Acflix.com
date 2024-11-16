using System.Security.Authentication;
using Application.Exceptions;
using Application.Models.User;
using Domain.User.Entities;
using Domain.User.ObjectValue;
using Domain.User.Repositories;
using Infrastructure.Authentication;
using Infrastructure.Notifications;
using MediatR;

namespace Application.Commands.Authentication;

public class AuthenticationCommandHandler(IUserRepository userRepository, IEmailSender emailSender, ICodeGenerator codeGenerator, IJwtProvider jwtProvider) :
    IRequestHandler<AuthenticateCommand, AuthResponse>,
    IRequestHandler<RegisterCommand, Guid>,
    IRequestHandler<RequestVerifyCommand>,
    IRequestHandler<RequestResetPasswordCommand>,
    IRequestHandler<ResetPasswordCommand>,
    IRequestHandler<VerifyCommand>



{
    public async Task<AuthResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByEmailAsync(request.Email);
        if (user is null)
            throw new UserAlreadyExistException("User not found with email " + request.Email);
        var token = jwtProvider.Generate(user);
        var response = new AuthResponse(user.RefreshToken, token);
        return response;
    }

    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var register = request.request;
        if (await userRepository.ExistByEmail(register.Email))
            throw new UserAlreadyExistException("User Already exist with email " + register.Email);
        var user = new User(
                email: register.Email,
                password: BCrypt.Net.BCrypt.HashPassword(register.Password),
                name: new Name(register.FirstName, register.LastName),
                phoneNumber: register.PhoneNumber,
                provider: UserProvider.ACFLIX,
                roles: [Role.USER],
                birthday: register.DateOfBirth,
                verifiedAt: null,
                avatarId: null
            );
        user = await userRepository.SaveAsync(user);
        return user.Id.Value;
    }

    public async Task Handle(RequestVerifyCommand request, CancellationToken cancellationToken)
    {
        //tao code
        var code = codeGenerator.Generate();
        var user = await userRepository.FindByEmailAsync(request.Email);
        if (user is null) throw new UserNotFoundException("Not found user with email " + request.Email);
        if (user.VerifiedAt is not null) throw new AuthenticationException("User already verified !");
        user.AddCode(code, 5, TokenType.VERIFY);

        //luu code
        user = await userRepository.SaveAsync(user);

        var task = emailSender.SendVerify(request.Email, code);
    }

    public async Task Handle(RequestResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByEmailAsync(request.Email);
        if (user is null) throw new UserNotFoundException("Not found user with email " + request.Email);
        var code = codeGenerator.Generate();
        user.AddCode(code, 5, TokenType.RESSET);
        user = await userRepository.SaveAsync(user);
        var task = emailSender.SendResetPassword(request.Email, code);
    }

    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByEmailAsync(request.Email);
        if (user is null) throw new UserNotFoundException("Not found user with email " + request.Email);
        user.ResetPassword(request.Password, request.Code);
        await userRepository.SaveAsync(user);
    }

    public async Task Handle(VerifyCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByEmailAsync(request.Email);
        if (user is null) throw new UserNotFoundException();
        user.Verify(request.Code);
        user = await userRepository.SaveAsync(user);
    }
}