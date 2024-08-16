using Microsoft.AspNetCore.Http;

namespace Infrastructure.Storage.Local;

public class LocalStorage :  ILocalStorage
{

    private const string TmpDir = @"D:\Workspace\.NET\Acflix\volumes\tmp";
    public async Task Storage(IFormFile inStream, string dest)
    {
        await using var fileStream = new FileStream(dest, FileMode.Create, FileAccess.Write);

        await inStream.CopyToAsync(fileStream);
    }

    public async Task<string> StorageToTmpAsync(IFormFile inStream)
    {
        var dest = Path.Join(TmpDir,Guid.NewGuid().ToString(), inStream.FileName);
        Directory.CreateDirectory(Path.GetDirectoryName(dest));
        await using var fileStream = new FileStream(dest, FileMode.Create, FileAccess.Write);
        await inStream.CopyToAsync(fileStream);

        return dest;
    }

    public Task<Stream> LoadBuffered(string dest)
    {
        throw new NotImplementedException();
    }
}