using Domain.Exceptions;
using Domain.Film.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Test.Domain
{
    public class EnumTest(ITestOutputHelper output)
    {


        [Fact]
        public void TestEnum()
        {
            //test form id
            var action = Genre.FromId(0);
            Assert.Equal(action, Genre.ACTION);


            //test from name
            var animation = Genre.FromName("animation");
            Assert.Equal(animation, Genre.ANIMATION);
            output.WriteLine(animation.ToString());

            //test throw
            Assert.Throws<EnumMappingException>(() => {
                Genre.FromId(50);
            });

            Assert.Throws<EnumMappingException>(() => {
                Genre.FromName("Pop");
            });
        }
    }
}
