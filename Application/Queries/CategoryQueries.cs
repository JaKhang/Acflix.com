using Application.Mappers;
using Application.Models.Base;
using Application.Models.Category;
using Application.Models.Film;
using Domain.Caterory;
using Domain.Image.Entities;
using Infrastructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class CategoryQueries (DatabaseContext context, ImageMapper imageMapper) : ICategoryQueries
{
    public async Task<Page<CategoryResponse>> FindAll(PageRequest pageRequest)
    {
        var category = await context.Categories.OrderBy(c => c.CreatedAt)
            .Skip(pageRequest.Offset)
            .Take(pageRequest.Limit)
            .ToListAsync();

        var total = await context.Categories.CountAsync();


        var categoryResponses = category.Select(c =>
        {
            var image = context.Images.Where(image => image.Id.Equals(c.CoverId)).FirstOrDefault();
            return map(c, image);
        }).ToList();


        Page<CategoryResponse> page = new Page<CategoryResponse>(
                total,
                categoryResponses,
                pageRequest.Offset == 0,
                pageRequest.Offset + pageRequest.Limit >= total,
                pageRequest.Offset + pageRequest.Limit / pageRequest.Limit,
                pageRequest.Limit,
                total / pageRequest.Limit
            );
        return page;
    }

    private CategoryResponse map(Category category, Image image)
    {

        return new CategoryResponse(
                Id: category.Id.Value,
                Name: category.Name,
                Icons: imageMapper.map(image)
            );
    }

    public Task<IEnumerable<FilmResponse>> FindFilmsById(Guid categoryId, PageRequest pageRequest)
    {
        throw new NotImplementedException();
    }
}