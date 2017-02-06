using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media
{
    using Geometry;

    public sealed class MediaRenditionInfo : ISize
    {
        public static string Host = "";
        public static ISigner Signer = null;

        private readonly string path;

        public MediaRenditionInfo(MediaTransformation transformation)
            : this(transformation, transformation.GetPath())
        { }

        public MediaRenditionInfo(ISize size, string path)
            : this(size.Width, size.Height, path)
        { }

        public MediaRenditionInfo(int width, int height, string path)
        {
            Width = width;
            Height = height;
            this.path = path;
        }

        public int Width { get; }

        public int Height { get; }

        [IgnoreDataMember]
        public bool IsEmpty => Width == 0 || Height == 0;

        public string TransformString
        {
            get
            {
                var parts = path.Split(Seperators.ForwardSlash);

                var sb = new StringBuilder();

                for (var i = 1; i < parts.Length; i++)
                {
                    if (i > 1)
                    {
                        sb.Append("/");
                    }

                    sb.Append(parts[i]);
                }

                return sb.ToString();
            }
        }

        public MediaRenditionInfo WithBackground(string hex)
        {
            if (hex.StartsWith("#"))
            {
                hex = hex.Substring(1);
            }

            var dotIndex = path.LastIndexOf('.');
            var spec = path.Substring(0, dotIndex);
            var format = path.Substring(dotIndex + 1);

            var newPath = $"{spec}/bg({hex}).{format}";

            return new MediaRenditionInfo(Width, Height, newPath);
        }

        public MediaRenditionInfo Resample(string name)
        {
            var dotIndex = path.LastIndexOf('.');
            var spec = path.Substring(0, dotIndex);
            var format = path.Substring(dotIndex + 1);

            var newPath = $"{spec}/resample({name}).{format}";

            return new MediaRenditionInfo(Width, Height, newPath);
        }

        public MediaRenditionInfo Blur(int radius)
        {
            var dotIndex = path.LastIndexOf('.');
            var spec = path.Substring(0, dotIndex);
            var format = path.Substring(dotIndex + 1);

            var newPath = $"{spec}/blur({radius}).{format}";

            return new MediaRenditionInfo(Width, Height, newPath);
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

            return new MediaRenditionInfo(Width, Height, newPath);
        }

        public MediaRenditionInfo Scale(double scale)
        {
            var a = MediaTransformation.ParsePath(path);

            var b = new MediaTransformation(a.Source, a.Format);

            foreach (var processor in a.GetTransforms())
            {
                if (processor is Resize)
                {
                    var resize = (Resize)processor;

                    b.Transform(resize * scale);
                }
                else if (processor is Crop)
                {
                    var crop = (Crop)processor;

                    b.Transform(new Crop(crop.Rectangle.Scale(scale)));
                }
                else
                {
                    b.Transform(processor);
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