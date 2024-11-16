using System.Security.Claims;
using Application.Commands;
using Application.Commands.Films;
using Application.Commands.Images;
using Application.Models.Base;
using Application.Models.Comment;
using Application.Models.Episode;
using Application.Models.Film;
using Application.Models.Vote;
using Application.Queries;
using Application.Queries.Comments;
using Application.Queries.Films;
using Application.Queries.Votes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minio.DataModel.ILM;
using Minio.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController(ISender sender)
        : ControllerBase
    {
        // GET: /api/v1/films
        [HttpGet]
        public async Task<IEnumerable<FilmResponse>> Get(ISet<Guid> ids)
        {
            throw new Exception();
        }

        // GET api/films/{id}
        [HttpGet("{id}")]
        public async Task<FilmResponse> Get(string id)
        {
            return await sender.Send(new FindFilmByIdQuery(Guid.Parse(id)));
        }

        [HttpPost("{id}/comments")]
        [Authorize]
        public async Task Put(string id, [FromBody] CommentRequest request)
        {
            // get current user id
            var userPrincipal = HttpContext.User;
            var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                throw new AuthorizationException("Id not exist in jwt");
            }
            await sender.Send(new CommentCommand(Guid.Parse(userId), Guid.Parse(id), request.Content));
        }

        [HttpGet("{id}/comments")]
        public async Task<Page<CommentResponse>> GetComments(string id, int offset = 0, int limit =50, string sort = "")
        {
            return await sender.Send(new FilmCommentQuery(Guid.Parse(id), offset, limit));
        }

        [HttpGet("{id}/relation")]
        public async Task<IEnumerable<FilmResponse>> GetRelated(string id)
        {
            return await sender.Send(new RelatedFilmsQuery(Guid.Parse(id)));
        }

        [HttpPut("{id}/relation")]
        public async Task AddRelated(string id, [FromQuery] IEnumerable<string> ids)
        {
           await sender.Send(new AddRelatedFilmCommand(Guid.Parse(id), ids.Select(Guid.Parse) ));
        }

        [HttpPost("{id}/episodes")]
        public async Task<Guid> AddEpisodes(string id, [FromForm] EpisodeRequest request)
        {
            var episode = await sender.Send(new AddNewEpisodeCommand(Guid.Parse(id), request.Name, request.Label));
            if (request.Src is not null)
            {
                var t = sender.Send(new ProcessEpisodeVideoCommand(request.Src, episode));

            }
            return episode;
        }

        [HttpGet("{id}/episodes")]
        public async Task<IEnumerable<EpisodeResponse>> GetEpisodes(string id)
        {
            return await sender.Send(new FindEpisodeByFilmQuery(Guid.Parse(id)));
        }

        [HttpGet("{id}/votes")]
        public async Task<VoteResponse> GetVote(string id)
        {
            // get current user id
            var userPrincipal = HttpContext.User;
            var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await sender.Send(new GetFilmVoteQuery(Guid.Parse(id), userId is null ? null : Guid.Parse(userId)));
        }

        [HttpPost("{id}/votes")]
        public async Task Vote(string id,[FromBody] VoteRequest request)
        {
            // get current user id
            var userPrincipal = HttpContext.User;
            var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                throw new AuthorizationException("Id not exist in jwt");
            }
            await sender.Send(new VoteCommand(request.Vote, Guid.Parse(userId), Guid.Parse(id)));
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<Guid> PostFilm([FromForm] FilmRequest request)
        {
            var coverId = await sender.Send(new UploadImageCommand(request.Cover, true));
            var posterId = await sender.Send(new UploadImageCommand(request.Poster, true));
            var createCommand = new CreateFilmCommand(
                CoverId: coverId,
                PosterId: posterId,
                Name: request.Name,
                OriginalName: request.OriginalName,
                Description: request.Description,
                Duration: request.Duration,
                Language: request.Language,
                AgeRestriction: request.AgeRestriction,
                Country: request.Country,
                Popularity: request.Popularity,
                ActorIds: request.ActorIds ?? Array.Empty<Guid>(),
                OriginalLanguage: request.OriginalLanguage,
                ReleaseDate: request.ReleaseDate,
                Precision: request.Precision,
                FilmStatus: request.FilmStatus,
                DirectorId: request.DirectorId,
                RelatedFilms: request.RelatedFilms ?? Array.Empty<Guid>(),
                Genres: request.Genres,
                Total: request.Total,
                FilmType: request.FilmType
            );
            var filmId = await sender.Send(createCommand);
            return filmId;
        }

        [HttpPost("movies/{id}/src")]
        [Authorize(Roles = "ADMIN")]
        public async Task AddMoveVideo(IFormFile src, string id)
        {
             await sender.Send(new ProcessMovieVideoCommand(src, Guid.Parse(id)));

        }

        [HttpGet("movies/{id}/src")]
        public async Task<string> GetStreamingUrl( string id)
        {
            return await sender.Send(new GetStreamLinkQuery(Guid.Parse(id)));

        }
    }
}