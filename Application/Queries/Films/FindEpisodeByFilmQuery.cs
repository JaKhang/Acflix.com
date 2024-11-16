using Application.Models.Episode;
using MediatR;

namespace Application.Queries.Films;

public record FindEpisodeByFilmQuery(Guid FilmId) : IRequest<IEnumerable<EpisodeResponse>>
{

}