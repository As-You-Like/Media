using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carbon.Geometry
{
    using Media;

    public struct Polygon
    {
        private readonly Vector2f[] _vertices;

        public Polygon(Vector2f[] vertices)
        {
            this._vertices = vertices;
        }

        public Polygon ToPercentages(Vector2f max)
        {
            var scaled = new Vector2f[Vertices.Length];

            var i = 0;

            foreach (var vector in _vertices)
            {
                scaled[i] = Vector2f.Create(vector.X / max.X, vector.Y / max.Y);

                i++;
            }

            return new Polygon(scaled);
        }

        public Polygon FromPercentages(ISize size)
        {
            var bounds = Vector2f.Create(size);

            var scaled = new Vector2f[Vertices.Length];

            var i = 0;

            foreach (var vector in _vertices)
            {
                scaled[i] = Vector2f.Create(vector.X * bounds.X, vector.Y * bounds.Y);

                i++;
            }

            return new Polygon(scaled);
        }

        public Vector2f[] Vertices => _vertices;

        public static Polygon FromData(byte[] data)
        {
            var vertices = new Vector2f[data.Length / 8];

            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
            {
                for (var i = 0; i < vertices.Length; i++)
                {
                    vertices[i] = Vector2f.Create(reader.ReadSingle(), reader.ReadSingle());
                }
            }

            return new Polygon(vertices);
        }

        // http://stackoverflow.com/questions/9815699/how-to-calculate-centroid
        public Vector2f Centroid
        {
            get
            {
                var accumulatedArea = 0.0f;
                var centerX = 0.0f;
                var centerY = 0.0f;

                for (int i = 0, j = _vertices.Length - 1; i < _vertices.Length; j = i++)
                {
                    var temp = _vertices[i].X * _vertices[j].Y - _vertices[j].X * _vertices[i].Y;

                    accumulatedArea += temp;

                    centerX += (_vertices[i].X + _vertices[j].X) * temp;
                    centerY += (_vertices[i].Y + _vertices[j].Y) * temp;
                }

                if (accumulatedArea == 0f)
                {
                    return new Vector2f();  // Avoid division by zero
                }

                accumulatedArea *= 3f;

                return new Vector2f
                {
                    X = centerX / accumulatedArea,
                    Y = centerY / accumulatedArea
                };
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                float minX = -1f,
                      maxX = -1f,
                      minY = -1f,
                      maxY = -1f;

                foreach (var vertex in _vertices)
                {
                    if (minX == -1f || vertex.X < minX) minX = vertex.X;
                    if (minY == -1f || vertex.Y < minY) minY = vertex.Y;

                    if (maxX == -1f || vertex.X > maxX) maxX = vertex.X;
                    if (maxY == -1f || vertex.Y > maxY) maxY = vertex.Y;
                }

                return new Rectangle((int)minX, (int)minY, (int)(maxX - minX), (int)(maxY - minY));
            }
        }

        public byte[] ToData()
        {
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms))
            {
                foreach (var v in Vertices)
                {
                    writer.Write(v.X);
                    writer.Write(v.Y);
                }

                return ms.ToArray();
            }
        }

        public override string ToString()
            => string.Join(" ", Vertices.Select(v => v.ToString()));
    }

    public struct Vector2f
    {
        [Column("x")]
        [DataMember(Name = "x")]
        public float X { get; set; }

        [Column("y")]
        [DataMember(Name = "y")]
        public float Y { get; set; }

        public static Vector2f Create(ISize size)
            => new Vector2f { X = size.Width, Y = size.Height };

        public static Vector2f Create(float x, float y)
            => new Vector2f { X = x, Y = y };

        public override string ToString() => X + "," + Y;

    }
}
