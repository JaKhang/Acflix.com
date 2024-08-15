using Domain.Base.ValueObjects;

namespace Domain.Caterory.Repositories;

public interface ICateRepository
{
    Task<Category>  SaveAsync(Category entity);

    Task<Category> FindByIdAsync(ID id);
        
    Task<Category> DeleteAsync(Category entity);
}