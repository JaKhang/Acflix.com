using Application.Commands.Films;
using Domain.Base.ValueObjects;
using Domain.Film.Entities;
using Hangfire;
using Infrastructure.Media;
using Infrastructure.Persistence;
using Infrastructure.Storage.Local;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.Worker;

public class VideoWorker(IVideoProcessor videoProcessor, ISender sender, ILogger<VideoWorker> logger,  IServiceScopeFactory serviceScopeFactory) : IVideoWorker
{
    public async Task DoWork(Id id, string originalFile)
    {
        var res =  await videoProcessor.ProcessAndUploadAsync(originalFile);
        logger.LogInformation(res.ToString());
        using var scope = serviceScopeFactory.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ISender>();
        await sender.Send(new AddMovieVideoCommand(id.Value, res.Reference, res.Duration, res.Quality, true));

    }

    public async Task DoForEpisode(Id episodeId, string file)
    {
        var res =  await videoProcessor.ProcessAndUploadAsync(file);
        logger.LogInformation(res.ToString());
        using var scope = serviceScopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        var e = await db.Episodes.FindAsync(episodeId);
        if (e is null)
        {
            throw new Exception();
        }
        e.AddVideo(new Video(res.Duration, res.Quality, true, res.Reference));
        db.Episodes.Update(e);
        await db.SaveChangesAsync();
    }
}