using Application.Models.Film;
using MediatR;

namespace Application.Queries.Films;

public record FindFilmByIdQuery(Guid Id) : IRequest<FilmResponse>;