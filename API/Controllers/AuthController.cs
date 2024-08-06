
using Application.Commands;
using Application.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    }
}
