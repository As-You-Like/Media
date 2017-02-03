using Xunit;

namespace Carbon.Media.Tests
{	
	public class DrawTextTests
	{
        [Fact]
        public void FromFullKey()
        {
            var draw = DrawText.Parse("text(Hello World,font:10px Helvetica,align:middle,x:0,y:10,width:100,color:red)");

            Assert.Equal("Hello World", draw.Text);
            Assert.Equal(Alignment.Middle, draw.Align);
            Assert.Equal(10, draw.Y.Value.Value);
            Assert.Equal(0, draw.X.Value.Value);
            Assert.Equal(100, draw.Width.Value.Value);
            Assert.Equal("red", draw.Color);
        }
	}
}