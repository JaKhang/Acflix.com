using Application.Models.Base;
using Application.Models.Film;
using Application.Queries.Films;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController(ISender sender) : ControllerBase
{


    [HttpGet("films")]
    public async Task<Page<FilmResponse>> UploadVideo(string keyword, int offset = 0, int limit = 20)
    {
        return await sender.Send(new FilmSearchQuery(keyword, offset, limit));
    }
}