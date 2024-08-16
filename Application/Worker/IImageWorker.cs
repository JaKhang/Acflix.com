using Domain.Base.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.Worker;

public interface IImageWorker
{
    Task DoWork(ID id, IFormFile file, bool resize);

    Task DoWork(ID id, string file, bool resize);

}