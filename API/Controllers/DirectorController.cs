using Application.Commands;
using Application.Commands.Directors;
using Application.Models.Director;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class DirectorController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<Guid> Create([FromBody] DirectorRequest request)
    {
        return await sender.Send(new CreateDirectorCommand(request.Name));
    }
}