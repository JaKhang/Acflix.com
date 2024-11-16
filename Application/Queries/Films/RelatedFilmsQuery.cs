using Application.Models.Film;
using MediatR;

namespace Application.Queries.Films;

public record RelatedFilmsQuery(Guid FilmId) : IRequest<IEnumerable<FilmResponse>>;