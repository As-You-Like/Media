using Xunit;

namespace Carbon.Media.Tests
{
    public class RationalTest
    {
        [Fact]
        public void ToDoubleTests()
        {
            Assert.Equal(10d, new Rational(10, 1).ToDouble());
            Assert.Equal(2d, new Rational(10, 5).ToDouble());
            Assert.Equal(0.5d, new Rational(1, 2).ToDouble());
            Assert.Equal(0.33333333333333331d, new Rational(1, 3).ToDouble());
        }

        [Fact]
        public void ToStringTests()
        {
            Assert.Equal("10", new Rational(10, 1).ToString());
            Assert.Equal("1/10", new Rational(1, 10).ToString());
            Assert.Equal("1000/1001", new Rational(1000, 1001).ToString());
        }
    }
}