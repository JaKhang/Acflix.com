using Microsoft.AspNetCore.Http;

namespace Application.Commands;

public interface IImageCommands
{
    Task<Guid> UploadImage(IFormFile file, bool resize);

    Task<Guid> UploadImage(string base64, bool resize);
}