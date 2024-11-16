using Application.Worker;
using Domain.Image.Entities;
using Domain.Image.Repositories;
using Hangfire;
using Infrastructure.Storage.Local;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Images;

public class ImageCommandHandler(IImageRepository repository, ILocalStorage localStorage ,IBackgroundJobClient backgroundJobClient, IImageWorker imageWorkers) : IRequestHandler<UploadImageCommand, Guid>
{
    public async Task<Guid> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        var image = new Image(request.FormFile.FileName);
        image = await repository.CreateAsync(image);
        var filePath = await localStorage.StorageToTmpAsync(request.FormFile);
        backgroundJobClient.Enqueue(() => imageWorkers.DoWork(image.Id, filePath, request.Resize));
        return image.Id.Value;
    }
}