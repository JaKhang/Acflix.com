using Application.Exceptions;
using Application.Models.Category;
using Domain.Base.ValueObjects;
using Domain.Caterory;
using Domain.Caterory.Repositories;
using Domain.Film.Repositories;

namespace Application.Commands;

public class CategoryCommands(ICateRepository cateRepository, IFilmRepository filmRepository) : ICategoryCommands 
{
    public async Task<Guid> Create(CategoryRequest request)
    {
        // var newCate = new Category(new ID(Guid.NewGuid()), null, request.Name);
        // await cateRepository.SaveAsync(newCate);
        throw new NotImplementedException();
    }

    public async Task AddFilm(Guid id, IEnumerable<Guid> filmIds)
    {
        var cate = await cateRepository.FindByIdAsync(new ID(id));
        if (cate is null) throw new ResourceNotFoundException("Cate not found with id " + id);
        foreach (var filmId in filmIds)
        {
            var film = await filmRepository.FindByIdAsync(new ID(filmId));
            cate.AddFilm(film);
        }
        await cateRepository.SaveAsync(cate);
    }

    public async Task Update(Guid id, CategoryRequest request)
    {
        var cate = await cateRepository.FindByIdAsync(new ID(id));
        if (cate is null) throw new ResourceNotFoundException("Cate not found with id " + id);
        cate.Update(request.Name);
        await cateRepository.SaveAsync(cate);
    }

    public async Task Hide(Guid id)
    {
        var cate = await cateRepository.FindByIdAsync(new ID(id));
        if (cate is null) throw new ResourceNotFoundException("Cate not found with id " + id);
        cate.isHide();
        await cateRepository.SaveAsync(cate);
    }

    public async Task Delete(Guid id)
    {
        var cate = await cateRepository.FindByIdAsync(new ID(id));
        if (cate is null) throw new ResourceNotFoundException("Cate not found with id " + id);
        await cateRepository.DeleteAsync(cate);
        await cateRepository.SaveAsync(cate);
    }
}