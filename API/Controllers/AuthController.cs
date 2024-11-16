
using System.Security.Authentication;
using System.Security.Claims;
using Application.Commands;
using Application.Commands.Authentication;
using Application.Models.User;
using MediatR;
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
    public class AuthController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<AuthResponse> Authenticate([FromBody] AuthRequest request)
        {
            return await sender.Send(new AuthenticateCommand(request.Email, request.Password));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var id = await sender.Send(new RegisterCommand(request));
            return new CreatedResult("", id);
        }

        [HttpGet("reset-password")]
        [Authorize]
        public async Task<IActionResult> ResetPassword(string email)
        {
            await sender.Send(new RequestResetPasswordCommand(email));
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
            await sender.Send(new ResetPasswordCommand(email, request.Password, request.Code));
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

            await sender.Send(new RequestVerifyCommand(email));
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

            await sender.Send(new VerifyCommand(verifyRequest.Code, email));
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
