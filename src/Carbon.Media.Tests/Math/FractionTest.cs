namespace Carbon.Math.Tests
{
	using Xunit;

	
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
	}
}