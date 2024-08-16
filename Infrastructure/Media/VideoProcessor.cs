using System.Text;
using Infrastructure.Storage.Local;
using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using Xabe.FFmpeg;

namespace Infrastructure.Media;

public class VideoProcessor(IMinioClient minioClient, HLSProperties properties) : IVideoProcessor
{
    public async Task<VideoProcessResult> ProcessAndUploadAsync(string filePath)
    {
        var mediaInfo = await FFmpeg.GetMediaInfo(filePath);
        var videoStream = mediaInfo.VideoStreams.FirstOrDefault();
        if (videoStream is null) throw new Exception();
        var resolution = videoStream.Height;
        var duration = videoStream.Duration.Seconds;
        var reference = Guid.NewGuid().ToString();
        var output = Path.Join(Path.GetDirectoryName(filePath), reference);;
        var conversion = new List<IConversion>();
        var master = new StringBuilder();
        master.Append("#EXTM3U");
        foreach (var quality in properties.Qualities)
        {
            if (quality.Resolution > resolution) continue;
            var qualityStream = FFmpeg.Conversions.New()
                .AddParameter("-y")
                .AddParameter($"-i {filePath}") // Input file
                .AddParameter($"-vf scale={quality.Scale}") // Resolution for 480p
                .AddParameter($"-c:v {quality.VideoCodec} -b:v {quality.VideoBitrate}") // Video codec and bitrate
                .AddParameter($"-c:a {quality.AudioCodeC} -b:a {quality.AudioBitrate}") // Audio codec and bitrate
                .AddParameter($"-hls_time {quality.SegmentDuration}")
                .AddParameter("-hls_playlist_type vod")
                .AddParameter($"-hls_segment_filename {output}/{quality.SegmentName}")
                .SetOutput(output + "/" + quality.Manifest);
            master.Append('\n')
                .Append($"#EXT-X-STREAM-INF:BANDWIDTH={quality.VideoBitrate.Replace("k", "000")},RESOLUTION={quality.Scale.Replace(':', 'x')}\n")
                .Append(quality.Manifest);
            await qualityStream.Start();
        }
        await File.WriteAllTextAsync(Path.Join(output, properties.Master), master.ToString());

        await UploadFolder(output);
        Directory.Delete(Path.GetDirectoryName(filePath), true);
        return new VideoProcessResult(resolution, duration, reference);


    }

    private async Task UploadFolder(string path)
    {
        var reference = Path.GetFileName(path);
        foreach (var file in Directory.GetFiles(path))
        {
            await using var stream = new FileStream(file, FileMode.Open);
            var fileName = Path.GetFileName(file);
            var param = new PutObjectArgs()
                .WithObject(reference + "/" +fileName)
                .WithStreamData(stream)
                .WithObjectSize(stream.Length)
                .WithBucket(properties.Bucket);
            await minioClient.PutObjectAsync(param);
        }
    }
}