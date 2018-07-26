using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    using Processors;

    public sealed class MediaRenditionInfo : ISize
    {
        private readonly string host;
        private readonly string seperator;
        private readonly IUrlSigner signer;

        public MediaRenditionInfo(
            string host, 
            MediaTransformation transformation,
            string seperator = "/",
            IUrlSigner signer = null)
            : this(
                  host          : host,
                  sourcePath    : transformation.Source.Key,
                  transformPath : transformation.GetFullName("/", prefix: null), 
                  width         : transformation.Width, 
                  height        : transformation.Height,
                  seperator     : seperator
                )
        { }

        public MediaRenditionInfo(
            string host,
            string sourcePath,
            string transformPath, 
            Size size, 
            string seperator = "/",
            IUrlSigner signer = null)
            : this(host, sourcePath, transformPath, size.Width, size.Height, seperator, signer)
        { }

        public MediaRenditionInfo(
            string host, 
            string sourcePath, 
            string transformPath, 
            int width,
            int height,
            string seperator = "/",
            IUrlSigner signer = null)
        {
            this.host      = host;
            SourcePath     = sourcePath    ?? throw new ArgumentNullException(nameof(sourcePath));
            TransformPath  = transformPath;
            this.seperator = seperator     ?? throw new ArgumentNullException(nameof(seperator));
            this.signer    = signer;

            Width  = width;
            Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public string SourcePath { get; }

        public string TransformPath { get; }

        [IgnoreDataMember]
        public bool IsEmpty => Width == 0 || Height == 0;

        public MediaRenditionInfo Blur(int radius)
        {
            var dotIndex = TransformPath.LastIndexOf('.');
            var spec     = TransformPath.Substring(0, dotIndex);
            var format   = TransformPath.Substring(dotIndex + 1);

            var newTransformPath = $"{spec}/blur({radius}).{format}";

            return new MediaRenditionInfo(host, SourcePath, newTransformPath, Width, Height, seperator, signer);
        }

        public MediaRenditionInfo Crop(Rectangle rect)
        {
            var transformation = MediaTransformation.ParsePath(Path);

            transformation.Crop(rect);

            return new MediaRenditionInfo(host, transformation, seperator, signer);
        }

        public MediaRenditionInfo WithFormat(string format)
        {
            var dotIndex = TransformPath.LastIndexOf('.');

            var newTransformPath = (dotIndex > -1 ? TransformPath.Substring(0, dotIndex) : TransformPath) + "." + format;

            return new MediaRenditionInfo(host, SourcePath, newTransformPath, Width, Height, seperator, signer);
        }

        public MediaRenditionInfo Scale(double scale)
        {
            var a = MediaTransformation.ParsePath(Path);

            var b = new MediaTransformation(a.Source);

            foreach (var transform in a.GetTransforms())
            {
                switch (transform)
                {
                    case ResizeTransform resize : b.Apply(resize * scale);      break;
                    case CropTransform crop     : b.Apply(crop.Scale(scale));   break;
                    default                     : b.Apply(transform);           break;
                }
            }

            return new MediaRenditionInfo(
                host          : host,
                sourcePath    : b.Source.Key, 
                transformPath : b.GetFullName("/", null), 
                width         : b.Width,
                height        : b.Height,
                seperator     : seperator,
                signer        : signer
            );
        }

        public string Url
        {
            get
            {
                var prefix = (host != null) ? "https://" + host : string.Empty;

                var path = Path;

                if (signer != null)
                {
                    return prefix + "/" + signer.Sign(path) + "/" + path;
                }

                return prefix + "/" + path;
            }
        }

        public string Path
        {
            get
            {
                if (TransformPath == null) return SourcePath;

                return string.Concat(SourcePath, seperator, TransformPath);
            }
        }
        public override string ToString() => Url;
    }
}