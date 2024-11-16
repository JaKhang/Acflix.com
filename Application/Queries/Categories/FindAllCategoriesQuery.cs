using Application.Models.Base;
using Application.Models.Category;
using Domain.Category;
using MediatR;

namespace Application.Queries.Categories;

public record FindAllCategoriesQuery(int Offset, int Limit) : IRequest<Page<CategoryResponse>>
{

}