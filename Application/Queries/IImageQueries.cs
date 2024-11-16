using Application.Models.Base;
using Application.Models.Image;
using Domain.Base.ValueObjects;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Queries;

public interface IImageQueries
{
    Task<IEnumerable<ImageResponse>> FindByIds(IEnumerable<Id> ids);

    Task<Page<ImageResponse>> FindPage(PageRequest pageRequest);

}