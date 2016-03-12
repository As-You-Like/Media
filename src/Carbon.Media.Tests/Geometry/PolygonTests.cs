using Xunit;

namespace Carbon.Geometry.Tests
{
    public class PolygonTests
    {
        [Fact]
        public void PolygonSerialier()
        {
            var a = new Vector2f[2];

            a[0] = Vector2f.Create(1, 2);
            a[1] = Vector2f.Create(3, 4.1f);

            var data = new Polygon(a).ToData();

            var vectors = Polygon.FromData(data).Vertices;

            Assert.Equal(1f, vectors[0].X);
            Assert.Equal(2f, vectors[0].Y);
            Assert.Equal(3f, vectors[1].X);
            Assert.Equal(4.1f, vectors[1].Y);
        }
    }
}
