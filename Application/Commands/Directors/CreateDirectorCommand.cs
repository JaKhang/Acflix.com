using MediatR;

namespace Application.Commands.Directors;

public record CreateDirectorCommand(string Name) : IRequest<Guid>;