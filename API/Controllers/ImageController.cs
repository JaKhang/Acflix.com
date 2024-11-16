using Application.Commands;
using Application.Commands.Images;
using Application.Models.Base;
using Application.Models.Image;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ImageController(ISender sender, IImageQueries imageQueries) : ControllerBase
{
    [HttpPost]
    public async Task<Guid> UploadImage(IFormFile image, bool resize = true)
    {
        return await sender.Send(new UploadImageCommand(image, resize));
    }

    [HttpGet("page")]
    public async Task<Page<ImageResponse>> FindAll(int limit = 20, int offset = 20)
    {
        return await imageQueries.FindPage(new PageRequest(offset, limit, string.Empty));
    }
}