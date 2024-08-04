namespace Domain.Film.Repositories
{
    public interface IFilmRepository
    {
        Entities.Film Save(Entities.Film entity);
    }
}
