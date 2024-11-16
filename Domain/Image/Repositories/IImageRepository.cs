using Domain.Base.ValueObjects;

namespace Domain.Image.Repositories;

public interface IImageRepository
{
    Task<Entities.Image> CreateAsync(Entities.Image image);

    Task UpdateAsync(Entities.Image image);


    Task Delete(Id id);

    Task<Entities.Image?> FindByIdAsync(Id id);
}