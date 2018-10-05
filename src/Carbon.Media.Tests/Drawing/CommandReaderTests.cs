using Xunit;

namespace Carbon.Media.Drawing.Tests
{
    public class DrawArgumentReaderTests
    {
        [Fact]
        public void Single()
        {
            var text = "circle(radius:5)";

            var reader = new DrawArgumentReader(text);

            Assert.True(reader.TryRead(out var command));

            // var circle = command as Circle;

            // Assert.Equal(5, circle.Radius);

            Assert.False(reader.TryRead(out _));
        }

        [Fact]
        public void Mixed1()
        {
            var text = "stroke:red,fill:blue";

            var reader = new DrawArgumentReader(text);

            Assert.True(reader.TryRead(out var stroke));
            Assert.True(reader.TryRead(out var file));
            
            Assert.False(reader.TryRead(out _));

            Assert.Equal("red", stroke.Value);
        }

        [Fact]
        public void Mixed2()
        {
            var text = "circle(radius:5), x: 100px, y: 50px, color: rgba(255, 255, 255, 10%)";

            var reader = new DrawArgumentReader(text);

            Assert.True(reader.TryRead(out var command));

            Assert.True(reader.TryRead(out var x));

            Assert.True(reader.TryRead(out var y));

            Assert.True(reader.TryRead(out var color));

            Assert.False(reader.TryRead(out _));

            Assert.Equal("x", x.Name);
            Assert.Equal("y", y.Name);
            Assert.Equal("color", color.Name);


            Assert.Equal("100px", x.Value);
            Assert.Equal("50px", y.Value);
            Assert.Equal("rgba(255, 255, 255, 10%)", color.Value);

        }

        [Fact]
        public void Multiple()
        {
            var text = "circle(radius:5),text(hello,font:12px Helvetica,x:10,y:10)";

            var reader = new DrawArgumentReader(text);

            Assert.True(reader.TryRead(out var circleArg));

            Assert.Equal("circle(radius:5)", circleArg.Value);

            Assert.True(reader.TryRead(out var textArg));

            Assert.Equal("text(hello,font:12px Helvetica,x:10,y:10)", textArg.Value);

            Assert.False(reader.TryRead(out var _));


            /*
            var circle = (Circle)circleCommand;

            Assert.Equal(5, circle.Radius);

            Assert.True(reader.TryRead(out var c));

            var textShape = (Text)c;

            Assert.Equal("hello", textShape.Content);
            Assert.Equal(10, textShape.Box.X);
            Assert.Equal(10, textShape.Box.Y);
            */
        }
     
    }
}
 
 