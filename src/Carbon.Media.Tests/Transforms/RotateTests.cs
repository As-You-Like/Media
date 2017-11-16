﻿using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class RotateTests
	{
		[Fact]
		public void ParseValues()
		{
            Assert.Equal(0,   Rotate.Parse("0").Angle);
            Assert.Equal(180, Rotate.Parse("180").Angle);
            Assert.Equal(360, Rotate.Parse("360").Angle);
            Assert.Equal(0,   Rotate.Parse("0deg").Angle);
            Assert.Equal(180, Rotate.Parse("180deg").Angle);
            Assert.Equal(360, Rotate.Parse("360deg").Angle);
        }

		[Fact]
		public void FromPartialKey()
		{
            Assert.Equal(0, Rotate.Parse("rotate(0)").Angle);
            Assert.Equal(360, Rotate.Parse("rotate(360)").Angle);
            Assert.Equal(360, Rotate.Parse("rotate(360deg)").Angle);
            // Assert.Equal(360, Rotate.Parse("rotate(1rad)").Angle);
        }
    }
}