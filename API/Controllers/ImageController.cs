using Application.Commands;
using Application.Models.Base;
using Application.Models.Image;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ImageController(IImageCommands imageCommands, IImageQueries imageQueries) : ControllerBase
{
    [HttpPost]
    public async Task<Guid> UploadImage(IFormFile image)
    {
        return await imageCommands.UploadImage(image, true);
    }

    [HttpGet("page")]
    public async Task<Page<ImageResponse>> FindAll(int limit = 20, int offset = 20)
    {
        return await imageQueries.FindPage(new PageRequest(offset, limit, string.Empty));
    }
}