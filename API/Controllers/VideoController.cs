using Application.Worker;
using Domain.Base.ValueObjects;
using Infrastructure.Media;
using Infrastructure.Storage.Local;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/[controller]s")]
[ApiController]
public class VideoController(IVideoWorker iVideoWorker, ILocalStorage localStorage, HLSProperties properties) : ControllerBase
{


    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [HttpPost]
    public async Task<IActionResult> UploadVideo(IFormFile video)
    {
        var tmpDir = Path.Join(properties.TempDir, Guid.NewGuid().ToString());
        var originalFile = Path.Join(tmpDir, video.FileName);
        Directory.CreateDirectory(tmpDir);
        await localStorage.Storage(video, originalFile);
        var task = iVideoWorker.DoWork(new Id(Guid.NewGuid()), originalFile);
        return new AcceptedResult();
    }
}