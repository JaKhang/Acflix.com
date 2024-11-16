using Application.Mappers;
using Application.Models.Base;
using Application.Models.Category;
using Application.Models.Film;
using Domain.Category;
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

    private static CategoryResponse Map(Category category, Image image)
    {

        return new CategoryResponse(
                Id: category.Id.Value,
                Name: category.Name,
                Icons: ImageMapper.Map(image).Variants
            );
    }

    public Task<IEnumerable<FilmResponse>> FindFilmsById(Guid categoryId, PageRequest pageRequest)
    {
        throw new NotImplementedException();
    }
}