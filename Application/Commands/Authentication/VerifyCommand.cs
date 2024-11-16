using MediatR;

namespace Application.Commands.Authentication;

public record VerifyCommand(string Code, string Email) : IRequest;