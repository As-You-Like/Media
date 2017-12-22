using Xunit;

namespace Carbon.Media.Drawing.Tests
{
    public class CommandReaderTests
    {
        [Fact]
        public void Single()
        {
            var text = "circle(radius:5)";

            var reader = new CommandReader(text);

            Assert.True(reader.TryRead(out var command));

            var circle = command as DrawCircleCommand;

            Assert.Equal(5, circle.Radius);

            Assert.False(reader.TryRead(out _));
        }

        [Fact]
        public void Multiple()
        {
            var text = "circle(radius:5),text(hello,font:12px Helvetica,x:10,y:10)";

            var reader = new CommandReader(text);

            Assert.True(reader.TryRead(out var circleCommand));

            var circle = (DrawCircleCommand)circleCommand;

            Assert.Equal(5, circle.Radius);

            Assert.True(reader.TryRead(out var c));

            var textShape = (DrawTextCommand)c;

            Assert.Equal("hello", textShape.Content);
            Assert.Equal(10, textShape.Box.X);
            Assert.Equal(10, textShape.Box.Y);
        }
    }
}