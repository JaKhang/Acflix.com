using Application.Models.Base;
using Application.Models.Category;
using Application.Models.Film;
using Application.Queries;
using Application.Queries.Films;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/browse")]
    [ApiController]
    public class BrowseController(ISender sender) : ControllerBase
    {
       [HttpGet("films/new-episode")]
        public async Task<Page<FilmResponse>> GetNewEpisode(int offset =0, int limit=20, string sort = "")
        {
            return await sender.Send(new FindFilmHasNewEpisodeQuery(offset, limit));
        }

        [HttpGet("films/new-released")]
        public async Task<Page<FilmResponse>> GetNewReleased(int offset =0, int limit=20, string sort = "")
        {
            return await sender.Send(new NewReleaseFIlmQuery(offset, limit));
        }

        [HttpGet("categories")]
        public async Task<IEnumerable<CategoryDetailsResponse>> GetCategories(int offset =0, int limit=20, int filmOffset = 0, int filmLimit = 10)
        {
            return await sender.Send(new FindCategoriesDetailsQuery(offset, limit, filmOffset, filmLimit));
        }
    }
}
