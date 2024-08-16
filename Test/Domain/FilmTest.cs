using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Test.Domain
{
    public class FilmTest(ITestOutputHelper output)
    {
        [Fact]
        void Test()
        {
            output.WriteLine(Path.Join("D:\\Workspace\\.NET\\Acflix\\volumes\\tmp", "image.jpg"));
        }
    }
}
