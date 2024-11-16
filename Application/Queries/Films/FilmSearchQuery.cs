using Application.Models.Base;
using Application.Models.Film;
using MediatR;

namespace Application.Queries.Films;

public record FilmSearchQuery(string Keyword, int Offset, int Limit) : IRequest<Page<FilmResponse>>;