namespace Carbon.Math.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class FractionTest
	{
		[Test]
		public void ToDoubleTests()
		{
			Assert.AreEqual(10d, new Fraction(10, 1).ToDouble());
			Assert.AreEqual(2d, new Fraction(10, 5).ToDouble());
			Assert.AreEqual(0.5d, new Fraction(1, 2).ToDouble());
			Assert.AreEqual(0.33333333333333331d, new Fraction(1, 3).ToDouble());
		}
	}
}