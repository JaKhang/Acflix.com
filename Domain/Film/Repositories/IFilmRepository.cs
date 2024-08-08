using Domain.Base.ValueObjects;

namespace Domain.Film.Repositories
{
    public interface IFilmRepository
    {
        Task<Entities.Film>  SaveAsync(Entities.Film entity);

        Task<Entities.Film> FindByIdAsync(ID id);

    }
}
