namespace Carbon.Math.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class FractionTest
	{
		[Test]
		public void ToDoubleTests()
		{
			Assert.AreEqual(10d, new Rational(10, 1).ToDouble());
			Assert.AreEqual(2d, new Rational(10, 5).ToDouble());
			Assert.AreEqual(0.5d, new Rational(1, 2).ToDouble());
			Assert.AreEqual(0.33333333333333331d, new Rational(1, 3).ToDouble());
		}
	}
}