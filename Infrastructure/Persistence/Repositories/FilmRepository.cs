using Domain.Base.ValueObjects;
using Domain.Film.Entities;
using Domain.Film.Repositories;

namespace Infrastructure.Persistence.Repositories;

public class FilmRepository : IFilmRepository
{
    public Task<Film> SaveAsync(Film entity)
    {
        throw new NotImplementedException();
    }

    public Task<Film> FindByIdAsync(ID id)
    {
        throw new NotImplementedException();
    }

    public Task<Film> DeleteAsync(Film entity)
    {
        throw new NotImplementedException();
    }
}