using Xunit;

namespace Carbon.Media.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("0.1", 0.1d, UnitType.Percent)]
        [InlineData("10%", 0.1d, UnitType.Percent)]
        [InlineData("100%", 1d, UnitType.Percent)]

        [InlineData("100", 100d, UnitType.Px)]
        [InlineData("100px", 100d, UnitType.Px)]
        [InlineData("10.5px", 10.5d, UnitType.Px)]
        [InlineData("50000", 50000d, UnitType.Px)]

        [InlineData("50.5 m", 50.5, UnitType.Meter)]

        [InlineData("_", 0d, UnitType.None)]
        public void Normalize(string input, double value, UnitType type)
        {
            var unit = Unit.Parse(input);

            Assert.Equal(value, unit.Value);
            Assert.Equal(type, unit.Type);
        }

        [Fact]
        public void Equality()
        {
            Assert.Equal(new Unit(1), new Unit(1));
            Assert.True(new Unit(1) == new Unit(1));
            Assert.True(new Unit(1) != new Unit(2));

            Assert.True(new Unit(5).Equals(new Unit(5)));
        }


        [Fact]
        public void DefaultEqualToNone()
        {
            Assert.True(Unit.None == default(Unit));
        }
    }
}
