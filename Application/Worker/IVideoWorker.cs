using Domain.Base.ValueObjects;
using Hangfire;
using Microsoft.AspNetCore.Http;

namespace Application.Worker;

public interface IVideoWorker
{
        Task DoWork(Id id, string file);

        Task DoForEpisode(Id episodeId, string file);

}