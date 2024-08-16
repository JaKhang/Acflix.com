using Microsoft.AspNetCore.Http;

namespace Infrastructure.Media;

public interface IVideoProcessor
{
    Task<VideoProcessResult> ProcessAndUploadAsync(string filePath);

}