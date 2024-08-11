using Application.Models.Base;
using Application.Models.Film;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/browse")]
    [ApiController]
    public class BrowseController(IFilmQueries filmQueries) : ControllerBase
    {
       [HttpGet("films/new-esopides")]
        public async Task<Page<FilmResponse>> GetNewEposides(int offset =0, int limit=20, string sort = "")
        {
            return await filmQueries.FindNewEpisode(new PageRequest(offset, limit, sort));
        }
    }
}
