using MediatR;

namespace Application.Commands.Films;

public record DeleteFilmCommand(Guid FilmId) : IRequest
{

}