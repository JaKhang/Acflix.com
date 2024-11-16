
using System.Globalization;
using System.Security.Claims;
using Application.Commands;
using Application.Models.Base;
using Application.Models.Film;
using Application.Models.User;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/me")]
    [ApiController]
    [Authorize]
    public class MeController(ISender sender) : ControllerBase
    {



        [HttpGet("")]
        public async Task<UserProfileResponse> GetInfo()
        {
            var userPrincipal = HttpContext.User;
            var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await sender.Send(new UserProfileQuery(Guid.Parse(userId)));
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
