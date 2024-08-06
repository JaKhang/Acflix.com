using Domain.Base.ValueObjects;

namespace Domain.Image.Repositories;

public interface IImageRepository
{
    Task<Entities.Image> SaveAsync(Entities.Image image);

    Task Delete(ID id);

    Task<Entities.Image> FindByIdAsync(ID id);
}