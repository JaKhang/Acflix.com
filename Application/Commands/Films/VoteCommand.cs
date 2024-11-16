using MediatR;

namespace Application.Commands.Films;

public record VoteCommand(int Vote, Guid UserId, Guid FilmId) : IRequest;
