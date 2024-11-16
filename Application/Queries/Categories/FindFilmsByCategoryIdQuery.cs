using Application.Models.Base;
using Application.Models.Film;
using MediatR;

namespace Application.Queries.Categories;

public record FindFilmsByCategoryIdQuery(Guid Id, int Offset, int Limit) : IRequest<Page<FilmResponse>>;