using Domain.Base.ValueObjects;
using Domain.Director;

namespace Infrastructure.Persistence.Repositories;

public class DirectorRepository(DatabaseContext context) : IDirectorRepository
{
    public async Task<Director> CreateAsync(Director director)
    {
        var rs = await context.Directors.AddAsync(director);
        await context.SaveChangesAsync();
        return rs.Entity;

    }
}