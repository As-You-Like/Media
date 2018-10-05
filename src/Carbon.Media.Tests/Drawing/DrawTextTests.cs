using Xunit;

namespace Carbon.Media.Drawing.Tests
{
    public class TextTests
	{
        [Fact]
        public void FromFullKey()
        {
            var syntax = CallSyntax.Parse("text(Hello World,font:10px Helvetica,color:red)");

            var draw = TextObject.Create(syntax);

            Assert.Equal("Hello World",    draw.Content);
            Assert.Equal("red",            draw.Color);
            
            Assert.Equal("text(Hello World,color:red,font:Helvetica)", draw.ToString());
        }

        [Fact]
        public void DrawText()
        {
            var draw = DrawCommand.Parse("draw(text(Hello World,font:10px Helvetica), align: center, fill: red,blendMode:Multiply)");
            
            Assert.Equal("draw(text(Hello World,font:Helvetica),align:Center,fill:red,blendMode:Multiply)", draw.ToString());
        }
    }
}