
using Application.Commands;
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




    }
}
