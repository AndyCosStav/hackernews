using hackernews.Classes;
using System;
using Xunit;

namespace hackernews.Tests
{
    public class Test
    {
        [Fact]
        public void ValidateStringTest()
        {
            Assert.Equal("Empty", Utility.ValidateString(""));
            Assert.Equal("Empty", Utility.ValidateString(" "));

            string test =
                "blahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblahblah";

            string halved = test.Substring(0, test.Length / 2) + "...";

            Assert.Equal(halved, Utility.ValidateString(test));


        }

        [Fact]
        public void ValidateUrlTest()
        {
            Assert.Equal("invalid URL", Utility.ValidateUrl("httf://blahblah.com"));
            Assert.Equal("http://blahblah.com", Utility.ValidateUrl("http://blahblah.com"));
            Assert.Equal("https://blahblah.com", Utility.ValidateUrl("https://blahblah.com"));

        }

        [Fact]
        public void ConvertComments()
        {
            Assert.Equal(26, Utility.ConvertComments("26comments"));
            Assert.Equal(2, Utility.ConvertComments("2comments"));

            Assert.Equal(0, Utility.ConvertComments("discuss"));
        }
    }
}
