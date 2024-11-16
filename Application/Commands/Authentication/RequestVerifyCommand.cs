using MediatR;

namespace Application.Commands.Authentication;

public record RequestVerifyCommand(string Email) : IRequest;