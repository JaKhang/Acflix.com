
using System.Security.Claims;
using Application.Commands;
using Application.Models.Comment;
using Application.Models.Film;
using Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FilmsController(IFilmQueries filmQueries, IFilmCommands filmCommands) : ControllerBase
    {
        // GET: /api/v1/films
        [HttpGet]
        public async Task<IEnumerable<FilmResponse>> Get(ISet<Guid> ids)
        {

            return await filmQueries.FindByIds(ids);
        }

        // GET api/films/{id}
        [HttpGet("{id}")]
        public async Task<FilmResponse> Get(string id)
        {
            return await filmQueries.FindById(Guid.Parse(id));
        }

        [HttpPost("{id}/comments")]
        public async Task Put(string id, [FromBody] CommentRequest request)
        {

            var userId = Guid.NewGuid();
            await filmCommands.Comment(Guid.Parse(id), userId, request);
        }




    }
}
