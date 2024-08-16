using Domain.Base.ValueObjects;
using Hangfire;
using Infrastructure.Media;
using Infrastructure.Storage.Local;
using Microsoft.AspNetCore.Http;

namespace Application.Worker;

public class VideoWorker(IVideoProcessor videoProcessor, IBackgroundJobClient backgroundJobClient, ILocalStorage localStorage, HLSProperties properties) : IVideoWorker
{
    public async Task DoWork(ID id, string originalFile)
    {
        backgroundJobClient.Enqueue(() => videoProcessor.ProcessAndUploadAsync(originalFile));
    }

    public Task DoForEpisode(ID episodeId, string file)
    {
        throw new NotImplementedException();
    }
}