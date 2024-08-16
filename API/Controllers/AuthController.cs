
using System.Security.Authentication;
using System.Security.Claims;
using Application.Commands;
using Application.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = Application.Models.User.RegisterRequest;
using ResetPasswordRequest = Application.Models.User.ResetPasswordRequest;

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
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var id = await authCommands.Register(request);
            return new CreatedResult("", id);
        }

        [HttpGet("reset-password")]
        [Authorize]
        public async Task<IActionResult> ResetPassword(string email)
        {
            await authCommands.RequestResetPasswordCode(email);
            return new AcceptedResult();
        }

        [HttpPut("reset-password")]
        [Authorize]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var userPrincipal = HttpContext.User;
            var email = userPrincipal.FindFirst(ClaimTypes.Email)?.Value;
            if (email is null)
            {
                throw new AuthenticationException("Email not exist in jwt");
            }
            await  authCommands.ResetPassword(request);
            return new NoContentResult();
        }

        [HttpGet("verify")]
        [Authorize]
        public async Task<IActionResult> Verify()
        {
            var userPrincipal = HttpContext.User;
            var email = userPrincipal.FindFirst(ClaimTypes.Email)?.Value;
            if (email is null)
            {
                throw new AuthenticationException("Email not exist in jwt");
            }
            await authCommands.RequestVerifyCode(email);
            return new AcceptedResult();
        }

        [HttpPut("verify")]
        [Authorize]
        public async Task<IActionResult> Verify([FromBody] VerifyRequest verifyRequest)
        {
            var userPrincipal = HttpContext.User;
            var email = userPrincipal.FindFirst(ClaimTypes.Email)?.Value;
            if (email is null)
            {
                throw new AuthenticationException("Email not exist in jwt");
            }
            await  authCommands.Verify(email, verifyRequest.Code);
            return new NoContentResult();
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
