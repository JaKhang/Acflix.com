using Minio;
using Minio.DataModel.Args;

namespace Test;

public class S3Test
{
    [Fact]
    async Task Test()
    {
        var minioClient = new MinioClient()
            .WithEndpoint("localhost:9000")
            .WithCredentials("jClphEFumsYL0fEjbL40", "CoQoJtyJOY1XFkfDAv0yu8x24FnBKPTjIf1QrORx")
            .Build();

        const string originalFile =
            @"D:\Workspace\.NET\Acflix\volumes\tmp\67c6c062-bf51-466f-8875-d8de02525912\sLfOBtHH0yW9eyGktpANmB3m1du.jpg";

        // using (var stream = new FileStream(originalFile, FileMode.Open))
        // {
        //     await minioClient.PutObjectAsync(new PutObjectArgs().WithObject(Guid.NewGuid().ToString())
        //         .WithObjectSize(stream.Length).WithBucket("image").WithStreamData(stream).WithContentType("image/jpg"));
        // }
        const string path =
            @"D:\Workspace\.NET\Acflix\volumes\tmp\25e49ed3-fea9-461a-9030-66c440347b66\fc8f04c8-d59b-4e78-8455-a34588947119";
        var reference = Path.GetFileName(path);
        foreach (var file in Directory.GetFiles(path))
        {
            await using var stream = new FileStream(file, FileMode.Open);
            var fileName = Path.GetFileName(file);
            var param = new PutObjectArgs()
                .WithObject(reference + "/" +fileName)
                .WithStreamData(stream)
                .WithObjectSize(stream.Length)
                .WithBucket("hls");
            await minioClient.PutObjectAsync(param);
        }
    }
}