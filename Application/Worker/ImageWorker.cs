using Domain.Base.ValueObjects;
using Domain.Image.Repositories;
using Infrastructure.Media;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Worker;

public class ImageWorker(
    IImageProcessor imageProcessor,
    ILogger<ImageWorker> logger,
    IServiceScopeFactory serviceScopeFactory) : IImageWorker
{
    public async Task DoWork(Id id, IFormFile file, bool resize)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        logger.LogInformation("Start process in background");

        var rs = await imageProcessor.ProcessAndUploadAsync(file, resize);
        var image = await dbContext.Images.FindAsync(id);
        logger.LogInformation("fine image " + image);

        if (image == null)
            return;
        rs.ForEach(result => image.AddVariants(result.Reference, result.Dimension));
        dbContext.Update(image);
        await dbContext.SaveChangesAsync();
    }

    public async Task DoWork(Id id, string file, bool resize)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        logger.LogInformation("Start process in background");

        var rs = await imageProcessor.ProcessAndUploadAsync(file, resize);
        var image = await dbContext.Images.FindAsync(id);
        logger.LogInformation("fine image " + image);

        if (image == null)
            return;
        rs.ForEach(result => image.AddVariants(result.Reference, result.Dimension));
        dbContext.Update(image);
        await dbContext.SaveChangesAsync();
    }
}