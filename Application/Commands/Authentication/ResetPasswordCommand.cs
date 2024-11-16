using MediatR;

namespace Application.Commands.Authentication;

public record ResetPasswordCommand(string Email, string Password, string Code) : IRequest;