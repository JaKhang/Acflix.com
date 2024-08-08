
using System.Security.Claims;
using Application.Commands;
using Application.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = Application.Models.User.RegisterRequest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthenticationCommands authCommands) : ControllerBase
    {
        [HttpPost]
        public async Task<AuthResponse> Authenticate([FromBody] AuthRequest request)
        {
            return await authCommands.Authenticate(request);
        }

        [HttpPost("register")]
        public async Task<Guid> Register([FromBody] RegisterRequest request)
        {
            return await authCommands.Register(request);
        }

        [HttpGet("verify")]
        public Task Verify()
        {
            var email = string.Empty;
            return  authCommands.RequestResetPasswordCode(email);
        }

        [HttpPost("authenticate")]
        public async Task<AuthResponse> Register([FromBody] AuthRequest request)
        {
            return await authCommands.Authenticate(request);
        }

        [HttpGet("test")]
        [Authorize(Roles = "ADMIN")]
        public string Test(){
            // get current user id
            var userPrincipal = HttpContext.User;
            var userId = userPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var s = userPrincipal.FindFirst(ClaimTypes.Email)?.Value;

            return userId;
        }


    }
}
