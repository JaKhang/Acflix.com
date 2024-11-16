using MediatR;

namespace Application.Commands.Films;

public record AddRelatedFilmCommand(Guid FilmId, IEnumerable<Guid> FilmIds) : IRequest
{

}