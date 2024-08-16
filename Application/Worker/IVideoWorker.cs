using Domain.Base.ValueObjects;
using Hangfire;
using Microsoft.AspNetCore.Http;

namespace Application.Worker;

public interface IVideoWorker
{
        Task DoWork(ID id, string file);

        Task DoForEpisode(ID episodeId, string file);

}