using MediatR;

namespace Application.Commands.Films;

public record CommentCommand(Guid UserId, Guid FilmId, string Content) : IRequest
{

}