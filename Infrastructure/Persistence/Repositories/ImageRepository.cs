using Domain.Base.ValueObjects;
using Domain.Image.Entities;
using Domain.Image.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistence.Repositories;

public class ImageRepository(DatabaseContext databaseContext) : IImageRepository
{
    public async Task<Image> CreateAsync(Image image)
    {
        var rs =  await databaseContext.Images.AddAsync(image);
        await databaseContext.SaveChangesAsync();
        return rs.Entity;
    }

    public async Task UpdateAsync(Image image)
    {
        databaseContext.Images.Update(image);
        await databaseContext.SaveChangesAsync();
    }

    public Task Delete(Id id)
    {
        throw new NotImplementedException();
    }

    public async Task<Image?> FindByIdAsync(Id id)
    {
        return await databaseContext.Images.FindAsync(id);
    }
}