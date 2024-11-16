using Domain.Base.ValueObjects;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Commands.Category;

public class CategoryCommandHandler(DatabaseContext databaseContext) : IRequestHandler<CreateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.Category.Category(name: request.Name, coverId: new Id(request.CoverId), filmIds: request.FilmIds.Select(f => new Id(f)).ToList(), popularity: request.Popularity);
        var res = databaseContext.Categories.Add(category);
        _ = await databaseContext.SaveChangesAsync(cancellationToken);
        return res.Entity.Id.Value;
    }
}