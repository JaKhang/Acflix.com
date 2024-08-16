using Application.Mappers;
using Application.Models.Base;
using Application.Models.Category;
using Application.Models.Film;
using Domain.Caterory;
using Domain.Image.Entities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class CategoryQueries (DatabaseContext context, ImageMapper imageMapper) : ICategoryQueries
{
    public async Task<Page<CategoryResponse>> FindAll(PageRequest pageRequest)
    {
        throw new NotImplementedException();

    }

    private CategoryResponse map(Category category, Image image)
    {

        return new CategoryResponse(
                Id: category.Id.Value,
                Name: category.Name,
                Icons: imageMapper.map(image).Variants
            );
    }

    public Task<IEnumerable<FilmResponse>> FindFilmsById(Guid categoryId, PageRequest pageRequest)
    {
        throw new NotImplementedException();
    }
}