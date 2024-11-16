using Application.Models.Base;
using Application.Models.Film;
using MediatR;

namespace Application.Queries.Films;

public record FindFilmHasNewEpisodeQuery(int Offset, int Limit) : IRequest<Page<FilmResponse>>;