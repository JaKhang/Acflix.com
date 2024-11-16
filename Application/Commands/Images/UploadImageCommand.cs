using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Images;

public record UploadImageCommand(IFormFile FormFile, bool Resize) : IRequest<Guid>
{
}
