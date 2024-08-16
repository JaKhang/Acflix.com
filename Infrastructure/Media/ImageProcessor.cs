using Domain.Image.Entities;
using Domain.Image.ValueObjects;
using Infrastructure.Storage.Local;
using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using Xabe.FFmpeg;

namespace Infrastructure.Media;

public class ImageProcessor(IMinioClient minioClient, ImageProperties imageProperties, ILocalStorage localStorage)
    : IImageProcessor
{
    public async Task<List<ImageProcessResult>> ProcessAndUploadAsync(IFormFile file, bool resize)
    {
        var tmpDir = Path.Join(imageProperties.TempDir, Guid.NewGuid().ToString());
        Directory.CreateDirectory(tmpDir);

        // save five to tmp
        var originalFile = Path.Join(tmpDir, file.FileName);
        await localStorage.Storage(file, originalFile);

        return await ProcessAndUploadAsync(originalFile, resize);
    }

    public async Task<List<ImageProcessResult>> ProcessAndUploadAsync(string originalFile, bool resize)
    {
        // resize
        var processResults = new List<ImageProcessResult>();
        var originalDimension = getDimension(originalFile);
        var tmpDir = Path.GetDirectoryName(originalFile);
        foreach (var width in imageProperties.Width)
        {
            if (width > originalDimension.Width) continue;
            var name = Guid.NewGuid().ToString();
            var dest = Path.Join(tmpDir, $"{name}.{imageProperties.Format}");
            var newDimension = getNewDemDimension(width, originalDimension);
            var conversion = FFmpeg.Conversions.New()
                .AddParameter($"-i {originalFile}") // Input file
                .AddParameter($"-vf scale={width}:{newDimension.Height}") // Scaling filter
                .SetOutput(dest);
            var rs = await conversion.Start();

            await using var stream = File.Open(dest, FileMode.Open);
            var s3Results = await minioClient.PutObjectAsync(
                new PutObjectArgs()
                    .WithObject(name)
                    .WithObjectSize(stream.Length)
                    .WithContentType($"image/{imageProperties.Format}")
                    .WithBucket("image")
                    .WithStreamData(stream));
            processResults.Add(new ImageProcessResult(newDimension, s3Results.ObjectName));
        }

        if (tmpDir is not null) Directory.Delete(tmpDir, true);

        // save to s3
        return processResults;
    }

    private Dimension getDimension(string target)
    {
        using var image = System.Drawing.Image.FromFile(target);
        return new Dimension(image.Width, image.Height);
    }

    private Dimension getNewDemDimension(int width, Dimension dimension)
    {
        return new Dimension(width, (dimension.Height * width) / dimension.Width);
    }
}