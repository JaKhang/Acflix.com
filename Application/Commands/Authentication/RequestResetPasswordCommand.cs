using MediatR;

namespace Application.Commands.Authentication;

public record RequestResetPasswordCommand(string Email) : IRequest;