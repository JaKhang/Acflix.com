
using System.Security.Claims;
using Application.Commands;
using Application.Models.Base;
using Application.Models.Comment;
using Application.Models.Episode;
using Application.Models.Film;
using Application.Models.Vote;
using Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/films")]
    [Authorize]
    [ApiController]
    public class FilmsController(IFilmQueries filmQueries, IFilmCommands filmCommands, ICommentQueries commentQueries, IVoteQueries voteQueries) : ControllerBase
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

        [HttpGet("{id}/comments")]
        public async Task<Page<CommentResponse>> GetComments(string id, int offset, int limit, string sort)
        {
            var pageRequest = new PageRequest(offset, limit, sort);
            return await commentQueries.FindByFilmId(Guid.Parse(id), pageRequest);
        }

        [HttpGet("{id}/relation")]
        public async Task<IEnumerable<FilmResponse>> GetRelated(string filmId)
        {
            return await filmQueries.FindRelatedFilms(Guid.Parse(filmId));
        }

        [HttpGet("{id}/eposides")]
        public async Task<IEnumerable<EpisodeResponse>> GetEposides(string filmId)
        {
            return await filmQueries.FindEpisodeByFilmId(Guid.Parse(filmId));
        }

        [HttpGet("{id}/votes")]
        public async Task<VoteResponse> GetVote(string id)
        {
            var userId = Guid.NewGuid();
            return await voteQueries.FindVoteByIdAsync(userId, Guid.Parse(id));
        }

    }
}
