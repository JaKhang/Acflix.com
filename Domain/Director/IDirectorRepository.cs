using Domain.Base.ValueObjects;

namespace Domain.Director;

public interface IDirectorRepository
{
    Task<Director> CreateAsync(Director director);
}