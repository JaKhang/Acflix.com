using Domain.Base.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.Worker;

public interface IImageWorker
{
    Task DoWork(Id id, IFormFile file, bool resize);

    Task DoWork(Id id, string file, bool resize);

}