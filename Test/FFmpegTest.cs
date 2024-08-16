using Xabe.FFmpeg;
using Xunit.Abstractions;

namespace Test;

public class FFmpegTest(ITestOutputHelper output)
{
    [Fact]
    public async Task Test()
    {
        var originalFile = @"C:\Users\PC\Downloads\test.mp4";
        var mediaInfo = await FFmpeg.GetMediaInfo(originalFile);
        var videoStream = mediaInfo.VideoStreams.FirstOrDefault();
        if (videoStream != null)
        {
            output.WriteLine($"Video Codec: {videoStream.Codec}");
            output.WriteLine($"Resolution: {videoStream.Width}x{videoStream.Height}");
            output.WriteLine($"Frame Rate: {videoStream.Framerate}");
            output.WriteLine($"Duration: {mediaInfo.Duration}");
        }

    }
    [Fact]
    public void TestMetadata()
    {
        var originalFile =
            "D:\\Workspace\\.NET\\Acflix\\volumes\\tmp\\f7ddb0e4-bf41-436e-ac07-4510c44f0741\\sLfOBtHH0yW9eyGktpANmB3m1du.jpg";
        var dest = "D:\\Workspace\\.NET\\Acflix\\volumes\\tmp\\f7ddb0e4-bf41-436e-ac07-4510c44f0741\\test.jpg";
        var conversion = FFmpeg.Conversions.New()
            .AddParameter($"-i {originalFile}")    // Input file
            .AddParameter($"-vf scale={600}:{900}") // Scaling filter
            .SetOutput(dest);
        conversion.Start();
    }



    [Fact]
    public async Task TestVideoProcess()
    {
        var originalFile =
            @"C:\Users\PC\Downloads\test.mp4";
        var dest = @"D:\Workspace\.NET\Acflix\volumes\tmp\f7ddb0e4-bf41-436e-ac07-4510c44f0741";
        Directory.CreateDirectory(dest);
        // Define the input file

    // Define output file paths
    string masterPlaylistPath = $"{dest}\\master.m3u8";
    string lowQualityPlaylistPath = $"{dest}\\low.m3u8";
    string midQualityPlaylistPath = $"{dest}\\mid.m3u8";
    string highQualityPlaylistPath = $"{dest}\\high.m3u8";

    // Create low quality stream (e.g., 480p)
    var lowQualityStream = FFmpeg.Conversions.New()
        .AddParameter("-y")
        .AddParameter($"-i {originalFile}")    // Input file
        .AddParameter("-vf scale=854:480") // Resolution for 480p
        .AddParameter("-c:v h264 -b:v 800k") // Video codec and bitrate
        .AddParameter("-c:a aac -b:a 128k") // Audio codec and bitrate
        .AddParameter("-hls_time 10")
        .AddParameter("-hls_playlist_type vod")
        .AddParameter($"-hls_segment_filename {dest}/low_%03d.ts")
        .SetOutput(lowQualityPlaylistPath);

    // Create mid quality stream (e.g., 720p)
    var midQualityStream = FFmpeg.Conversions.New()
        .AddParameter("-y")
        .AddParameter($"-i {originalFile}")    // Input file
        .AddParameter("-vf scale=1280:720") // Resolution for 720p
        .AddParameter("-c:v h264 -b:v 2000k") // Video codec and bitrate
        .AddParameter("-c:a aac -b:a 128k") // Audio codec and bitrate
        .AddParameter("-hls_time 10")
        .AddParameter("-hls_playlist_type vod")
        .AddParameter($"-hls_segment_filename {dest}/mid_%03d.ts")
        .SetOutput(midQualityPlaylistPath);

    // Create high quality stream (e.g., 1080p)
    // var highQualityStream = FFmpeg.Conversions.New()
    //     .AddParameter($"-i {originalFile}")    // Input file
    //     .AddParameter("-y")
    //     .AddParameter("-vf scale=1920:1080") // Resolution for 1080p
    //     .AddParameter("-c:v h264 -b:v 5000k") // Video codec and bitrate
    //     .AddParameter("-c:a aac -b:a 192k") // Audio codec and bitrate
    //     .AddParameter("-hls_time 10")
    //     .AddParameter("-hls_playlist_type vod")
    //     .AddParameter($"-hls_segment_filename {dest}/high_%03d.ts")
    //     .SetOutput(highQualityPlaylistPath);

    // Run the conversion for each quality level
    await Task.WhenAll(lowQualityStream.Start(), midQualityStream.Start());

    // Create a master playlist that links to each quality level
    string masterPlaylistContent =
        "#EXTM3U\n" +
        "#EXT-X-STREAM-INF:BANDWIDTH=800000,RESOLUTION=854x480\n" +
        "low.m3u8\n" +
        "#EXT-X-STREAM-INF:BANDWIDTH=2000000,RESOLUTION=1280x720\n" +
        "mid.m3u8\n";

    // Write the master playlist to file
    await File.WriteAllTextAsync(masterPlaylistPath, masterPlaylistContent);
    }

    [Fact]
    public void TestPath()
    {
        output.WriteLine(string.Join(", ", Directory.GetFiles(@"D:\Workspace\.NET\Acflix\volumes\tmp\ff943ef8-cbf7-4e14-99bf-3b55995884c7\dfd0fcdc-fdfd-48b8-8211-4e85575f5dc9")));
    }
}