
using System.Globalization;
using System.Security.Claims;
using Application.Commands;
using Application.Models.Base;
using Application.Models.Film;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/me")]
    [ApiController]
    public class MeController : ControllerBase
    {

        private readonly IFilmQueries _filmQueries;
        private readonly IUserCommands _userCommands;
        private readonly IUserQueries userQueries;

        [HttpGet("films")]
        public async Task<Page<FilmResponse>> GetSavedFilms(int offset =0, int limit=20, string sort = "")
        {
            var userPrincipal = HttpContext.User;
            var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _filmQueries.FindUserSaved(Guid.Parse(userId), new PageRequest(offset, limit, sort));
        }

        [HttpGet("films/{contains}")]
        public async Task<IEnumerable<FilmResponse>> GetFilms(string ids)
        {
            var userPrincipal = HttpContext.User;
            var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _filmQueries.CheckSaved(Guid.Parse(userId), ids);
        }

        // [HttpDelete("films")]
        // public async Task DeleteSavedFilms(ISet<Guid> ids)
        // {
        //     var userPrincipal = HttpContext.User;
        //     var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     await _userCommands.DeleteSavedFilms(Guid.Parse(userId), ids);
        // }



    }
}
