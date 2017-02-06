using Xunit;

namespace Carbon.Media.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("0.1", 0.1d, UnitType.Percent)]
        [InlineData("10％", 0.1d, UnitType.Percent)]
        [InlineData("100％", 1d, UnitType.Percent)]

        [InlineData("100", 100d, UnitType.Px)]
        [InlineData("100px", 100d, UnitType.Px)]
        [InlineData("10.5px", 10.5d, UnitType.Px)]
        [InlineData("50000", 50000d, UnitType.Px)]

        [InlineData("_", 0d, UnitType.None)]
        public void Normalize(string input, double value, UnitType type)
        {
            var unit = Unit.Parse(input);

            Assert.Equal(value, unit.Value);
            Assert.Equal(type, unit.Type);
        }
    }
}