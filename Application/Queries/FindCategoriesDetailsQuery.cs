using Application.Models.Category;
using Domain.Film.Entities;
using MediatR;

namespace Application.Queries;

public record FindCategoriesDetailsQuery(int Offset, int Limit, int FilmOffset, int FilmLimit) : IRequest<IEnumerable<CategoryDetailsResponse>>;