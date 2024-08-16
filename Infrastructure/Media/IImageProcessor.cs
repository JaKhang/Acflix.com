using Domain.Image.Entities;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Media;

public interface IImageProcessor
{
    Task<List<ImageProcessResult>> ProcessAndUploadAsync(IFormFile file, bool resize);

    Task<List<ImageProcessResult>> ProcessAndUploadAsync(string pathfile, bool resize);

}