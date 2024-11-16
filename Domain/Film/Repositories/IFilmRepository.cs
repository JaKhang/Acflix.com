using Domain.Base.ValueObjects;

namespace Domain.Film.Repositories
{
    public interface IFilmRepository
    {
        Task<Entities.Film>  SaveAsync(Entities.Film entity);

        Task<Entities.Film?> FindByIdAsync(Id id);

        Task<Entities.Series?> FindSeriesByIdAsync(Id id);

        Task DeleteAsync(Id id);

        Task<Entities.Film> Create(Entities.Film film);
        Task<bool> ExistMovieById(Id id);
    }
}
