using Domain.Base.ValueObjects;
using Domain.Film.Entities;
using Domain.Film.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class FilmRepository(DatabaseContext databaseContext) : IFilmRepository
{
    public async Task<Film> SaveAsync(Film entity)
    {
        databaseContext.Update(entity);
        await databaseContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Film?> FindByIdAsync(Id id)
    {
        return await databaseContext.Films.Include(f => f.RelatedFilmIds).Where(f => f.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Series?> FindSeriesByIdAsync(Id id)
    {
        return await databaseContext.Series.Include(f => f.Episodes).Where(f => f.Id == id).FirstOrDefaultAsync();

    }

    public Task DeleteAsync(Id id)
    {
        throw new NotImplementedException();
    }

    public async Task<Film> Create(Film film)
    {
        var rs =  await databaseContext.Films.AddAsync(film);
        await databaseContext.SaveChangesAsync();
        return rs.Entity;
    }

    public async Task<bool> ExistMovieById(Id id)
    {
        return (await databaseContext.Movies.FindAsync(id)) is not null;
    }
}