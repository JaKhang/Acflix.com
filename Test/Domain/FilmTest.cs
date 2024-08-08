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
            output.WriteLine(BCrypt.Net.BCrypt.HashPassword("admin"));
        }
    }
}
