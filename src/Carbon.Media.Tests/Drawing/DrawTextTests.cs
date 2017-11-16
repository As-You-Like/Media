using Xunit;

namespace Carbon.Media.Drawing.Tests
{
    public class TextTests
	{
        [Fact]
        public void FromFullKey()
        {
            var draw = TextShape.Parse("text(Hello World,font:10px Helvetica,align:middle,x:0,y:10,width:100,padding:10,color:red)");

            Assert.Equal("Hello World",     draw.Content);
            Assert.Equal(Alignment.Middle,  draw.Align);
            Assert.Equal(10,                draw.Box.Y.Value.Value);
            Assert.Equal(0,                 draw.Box.X.Value.Value);
            Assert.Equal(100,               draw.Box.Width.Value.Value);
            Assert.Equal(10,                draw.Box.Padding.Left.Value);
            Assert.Equal("red",             draw.Color);
            
            Assert.Equal("text(Hello World,color:red,font:Helvetica,x:0,y:10,width:100,align:middle,padding:10)", draw.ToString());
        }
	}
}