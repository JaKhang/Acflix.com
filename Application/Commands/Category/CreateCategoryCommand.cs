using MediatR;

namespace Application.Commands.Category;

public record CreateCategoryCommand(string Name, Guid CoverId, IEnumerable<Guid> FilmIds, int Popularity) : IRequest<Guid>;