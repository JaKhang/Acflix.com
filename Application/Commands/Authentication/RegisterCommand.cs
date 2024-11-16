using Application.Models.User;
using MediatR;

namespace Application.Commands.Authentication;

public record RegisterCommand(RegisterRequest request): IRequest<Guid>
{

}