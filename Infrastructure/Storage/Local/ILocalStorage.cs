using Microsoft.AspNetCore.Http;

namespace Infrastructure.Storage.Local;

public interface ILocalStorage
{
    Task Storage(IFormFile file, string dest);

    Task<string> StorageToTmpAsync(IFormFile file);

    Task<Stream> LoadBuffered(string dest);
}