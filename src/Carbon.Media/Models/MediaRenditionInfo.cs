using System.Linq;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    using Helpers;
    using Geometry;

    public sealed class MediaRenditionInfo : ISize
    {
        public static string Host = "";
        public static ISigner Signer = null;

        private readonly int width;
        private readonly int height;
        private readonly string path;

        public MediaRenditionInfo(MediaTransformation transformation)
            : this(transformation, transformation.GetPath())
        { }

        public MediaRenditionInfo(ISize size, string path)
            : this(size.Width, size.Height, path)
        { }

        public MediaRenditionInfo(int width, int height, string path)
        {
            this.width = width;
            this.height = height;
            this.path = path;
        }

        public int Width => width;

        public int Height => height;

        [IgnoreDataMember]
        public bool IsEmpty => width == 0 || height == 0;

        public string TransformString => string.Join("/", path.Split('/').Skip(1));

        public MediaRenditionInfo WithBackground(string hex)
        {
            if (hex.StartsWith("#")) hex = hex.Trim('#');

            var dotIndex = path.LastIndexOf('.');
            var spec = path.Substring(0, dotIndex);
            var format = path.Substring(dotIndex + 1);

            var newPath = $"{spec}/bg({hex}).{format}";

            return new MediaRenditionInfo(width, height, newPath);
        }

        public MediaRenditionInfo Resample(string name)
        {
            var dotIndex = path.LastIndexOf('.');
            var spec = path.Substring(0, dotIndex);
            var format = path.Substring(dotIndex + 1);

            var newPath = $"{spec}/resample({name}).{format}";

            return new MediaRenditionInfo(width, height, newPath);
        }

        public MediaRenditionInfo Blur(int radius)
        {
            var dotIndex = path.LastIndexOf('.');
            var spec = path.Substring(0, dotIndex);
            var format = path.Substring(dotIndex + 1);

            var newPath = $"{spec}/blur({radius}).{format}";

            return new MediaRenditionInfo(width, height, newPath);
        }

        public MediaRenditionInfo Crop(Rectangle rect)
        {
            var transformation = MediaTransformation.ParsePath(this.path);

            transformation.Crop(rect);

            return new MediaRenditionInfo(transformation);
        }

        public MediaRenditionInfo WithFormat(string format)
        {
            var dotIndex = path.LastIndexOf('.');

            var newPath = path.Substring(0, dotIndex) + "." + format;

            return new MediaRenditionInfo(width, height, newPath);
        }

        public MediaRenditionInfo Scale(float scale)
        {
            var a = MediaTransformation.ParsePath(path);

            var b = new MediaTransformation(a.Source, a.Format);

            foreach (var transform in a.GetTransforms())
            {
                if (transform is Resize)
                {
                    var resize = (Resize)transform;

                    b.Transform(new Resize(resize.Size.Scale(scale)));
                }
                else if (transform is AnchoredResize)
                {
                    var resize = (AnchoredResize)transform;

                    b.Transform(new AnchoredResize(resize.Size.Scale(scale), resize.Anchor));
                }
                else if (transform is Crop)
                {
                    var crop = (Crop)transform;

                    b.Transform(new Crop(crop.Rectangle.Scale(scale)));
                }
                else
                {
                    b.Transform(transform);
                }
            }

            return new MediaRenditionInfo(b.Width, b.Height, b.GetPath());
        }

        public string Url
        {
            get
            {
                // TODO: Cache the prefix

                var prefix = (Host != null) ? "https://" + Host : "";

                if (Signer != null)
                {
                    return prefix + "/" + Signer.Sign(path) + "/" + path;
                }

                return prefix + "/" + path;
            }
        }

        public override string ToString() => Url;
    }

    public interface ISigner
    {
        string Sign(string path);
    }
}