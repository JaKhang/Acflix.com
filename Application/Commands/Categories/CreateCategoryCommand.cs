using MediatR;

namespace Application.Commands.Categories;

public record CreateCategoryCommand(
    string Name,
    IEnumerable<Guid> FilmIds
) : IRequest<Guid>;