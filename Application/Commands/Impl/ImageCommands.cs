using Application.Worker;
using Domain.Base.ValueObjects;
using Domain.Image.Entities;
using Domain.Image.Repositories;
using Domain.User.ObjectValue;
using Hangfire;
using Infrastructure.Media;
using Infrastructure.Storage.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Impl;

public class ImageCommands(IImageRepository repository, ILocalStorage localStorage ,IBackgroundJobClient backgroundJobClient,ILogger<ImageCommands> logger, IImageWorker imageWorkers) : IImageCommands
{
    public async Task<Guid> UploadImage(IFormFile file, bool resize)
    {
        logger.LogInformation("Start save metadata");
        var image = new Image(file.FileName);
        image = await repository.CreateAsync(image);
        var filePath = await localStorage.StorageToTmpAsync(file);
        backgroundJobClient.Enqueue(() => imageWorkers.DoWork(image.Id, filePath, resize));
        return image.Id.Value;
    }



    public Task<Guid> UploadImage(string base64, bool resize)
    {
        throw new NotImplementedException();
    }
}