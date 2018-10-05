using Xunit;

namespace Carbon.Media.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("1", 1d, UnitType.None)]
        [InlineData("100", 100d, UnitType.None)]
        [InlineData("50000", 50000d, UnitType.None)]
        [InlineData("0.1", 0.1d, UnitType.None)]


        [InlineData("10%", 10d, UnitType.Percentage)]
        [InlineData("100%", 100d, UnitType.Percentage)]

        [InlineData("100px", 100d, UnitType.Px)]
        [InlineData("10.5px", 10.5d, UnitType.Px)]

        [InlineData("100m", 100, UnitType.M)]
        [InlineData("50.5 m", 50.5, UnitType.M)]

        [InlineData("_", 0d, UnitType.None)]
        public void Normalize(string input, double value, UnitType type)
        {
            var unit = Unit.Parse(input);

            Assert.Equal(value, unit.Value);
            Assert.Equal(type, unit.Type);
        }
        
        [Fact]
        public void BM2()
        {
            // 305
            for (var i = 0; i < 1_000_000; i++)
            {

                Unit.Parse("100.1px");
            }
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
        public void NoneIsDefault()
        {
            Assert.True(Unit.None == default);
        }
    }
}
