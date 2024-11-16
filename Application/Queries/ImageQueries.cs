using Application.Mappers;
using Application.Models.Base;
using Application.Models.Image;
using Domain.Base.ValueObjects;
using Domain.Image.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class ImageQueries(DatabaseContext db, ImageMapper imageMapper) : IImageQueries
{
    public async Task<IEnumerable<ImageResponse>> FindByIds(IEnumerable<Id> ids)
    {
        var images = await db.Images
            .Include(i => i.Variants)
            .Where(image => ids.Contains(image.Id) && !image.IsDeleted)
            .ToListAsync();
        return images.Select(ImageMapper.Map);
    }

    public async Task<Page<ImageResponse>> FindPage(PageRequest pageRequest)
    {
        var images = await db.Images
            .Include(i => i.Variants)
            .OrderByDescending(i => i.CreatedAt)
            .Skip(pageRequest.Offset)
            .Take(pageRequest.Limit)
            .ToListAsync();

        var count = db.Images.Count();
        return new Page<ImageResponse>(
            Items: images.Select(ImageMapper.Map),
            Limit: pageRequest.Limit,
            IsFirst: pageRequest.Offset == 0,
            IsLast: images.Count < pageRequest.Offset,
            Offset: pageRequest.Offset,
            TotalItems: count
        );
    }
}