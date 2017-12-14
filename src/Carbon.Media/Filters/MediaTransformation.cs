using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media
{
    using Drawing;
    using Processors;

    public class MediaTransformation
    {
        protected readonly List<ITransform> transforms = new List<ITransform>();

        private int width;
        private int height;
        private Encode encoder;

        public MediaTransformation(IMediaInfo source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            width  = source.Width;
            height = source.Height;

            if (source.Orientation != null)
            {
                Apply(source.Orientation.Value.GetTransforms());
            }
        }

        public IMediaInfo Source { get; }

        public int Width => width;

        public int Height => height;

        public Encode Encoder => encoder;

        public FormatId Format => encoder.Format;

        public Size Size => new Size(width, height);

        public IReadOnlyList<ITransform> GetTransforms() => transforms.AsReadOnly();

        public MediaTransformation Apply(params ITransform[] processors)
        {
            #region Preconditions

            if (processors == null)
                throw new ArgumentNullException(nameof(processors));

            #endregion

            if (processors.Length == 0) return this;

            foreach (var processor in processors)
            {
                Apply(processor);
            }

            return this;
        }

        private MediaTransformation Apply(ITransform transform)
        {
            if (transform is Crop crop)
            {
                var rect = crop.GetRectangle(Size);

                width = rect.Width;
                height = rect.Height;
            }
            else if (transform is Resize resize)
            {
                var newSize = resize.CalcuateSize(Size);

                width = newSize.Width;
                height = newSize.Height;
            }
            else if (transform is Scale scale)
            {
                width = scale.Width;
                height = scale.Height;
            }
            else if (transform is Rotate rotate)
            {
                // Flip the height & width
                if (rotate.Angle == 90 || rotate.Angle == 270)
                {
                    var oldWidth = width;
                    var oldHeight = height;

                    width = oldHeight;
                    height = oldWidth;
                }
            }
            else if (transform is Pad pad)
            {
                width += (pad.Left + pad.Right);
                height += (pad.Top + pad.Bottom);
            }
            else if (transform is Encode encode)
            {
                encoder = encode;
            }

            this.transforms.Add(transform);

            return this;
        }

        #region Builders

        public MediaTransformation Rotate(int angle)
        {
            Apply(new Rotate(angle));

            return this;
        }

        public MediaTransformation Crop(Rectangle rect)
        {
            Apply(new Crop(rect));

            return this;
        }

        public MediaTransformation Clip(TimeSpan start, TimeSpan end)
        {
            Apply(new Clip(start, end));

            return this;
        }

        public MediaTransformation Draw(params Shape[] shapes)
        {
            Apply(new DrawFilter(shapes));

            return this;
        }

        public MediaTransformation Crop(int x, int y, int width, int height)
        {
            Apply(new Crop(x, y, width, height));

            return this;
        }

        public MediaTransformation Resize(int width, int height, CropAnchor anchor)
        {
            Apply(new Resize(new Size(width, height), anchor));

            return this;
        }

        public MediaTransformation Resize(Unit width, Unit height)
        {
            Apply(new Resize(width, height, ResizeFlags.Exact));

            return this;
        }

        public MediaTransformation Resize(int width, int height)
        {
            Apply(new Resize(width, height));

            return this;
        }

        public MediaTransformation WithQuality(int value)
        {
            Apply(new Quality(value));

            return this;
        }

        public MediaTransformation WithBackground(string color)
        {
            Apply(new BackgroundFilter(color));

            return this;
        }

        public MediaTransformation WithPage(int number)
        {
            Apply(new PageFilter(number));

            return this;
        }

        public MediaTransformation WithColorSpace(ColorSpace colorSpace)
        {
            Apply(new ColorSpaceFilter(colorSpace));

            return this;
        }

        public MediaTransformation Blur(float radius)
        {
            Apply(new BlurFilter(radius));

            return this;
        }

        public MediaTransformation Encode(ImageFormat format, int? quality = null)
        {
            return Encode((FormatId)format, quality);
        }

        public MediaTransformation Encode(FormatId format, int? quality)
        {
            if (encoder != null)
            {
                throw new Exception("An encoder has already been set");
            }

            encoder = new Encode(format, quality);

            Apply(encoder);

            return this;
        }

        #endregion

        #region Helpers

        [IgnoreDataMember]
        public bool HasTransforms => transforms.Count > 0;

        private static readonly char[] transformPathSeperators = new[] { ';', '/' };

        public static MediaTransformation ParsePath(string path, IMediaInfo source = null)
        {
            #region Preconditions

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (path.Length < 3)
            {
                throw new ArgumentException("May not be empty", nameof(path));
            }

            #endregion

            if (path[0] == '/')
            {
                path = path.Substring(1);
            }

            // {sourcePath}/{transform}.{format}

            int lastDotIndex        = path.LastIndexOf('.');
            int firstSeperatorIndex = path.IndexOfAny(transformPathSeperators); // { ';', '/' }

            if (lastDotIndex == -1)
            {
                throw new Exception("Missing format");
            }
           
            string key             = path.Substring(0, firstSeperatorIndex);
            string transformString = path.Substring(firstSeperatorIndex + 1, lastDotIndex - (firstSeperatorIndex + 1));
            string format          = path.Substring(lastDotIndex + 1);

            var segments = transformString.Split(Seperators.ForwardSlash);

            var transforms = ParseTransforms(segments);

            var rendition = new MediaTransformation(source ?? new MediaInfo(key, 0, 0))
                .Apply(transforms)
                .Encode(FormatIdExtensions.Parse(format), null);

            return rendition;
        }

        public static ITransform[] ParseTransforms(string[] segments)
        {
            var transforms = new ITransform[segments.Length];

            for (var i = 0; i < segments.Length; i++)
            {
                var segment = segments[i];

                ITransform transform;

                if (char.IsDigit(segment[0]))
                {
                    transform = Processors.Resize.Parse(segment);   
                }
                else
                {
                    transform = Transform.Parse(segment);
                }

                transforms[i] = transform;
            }

            return transforms;
        }

        // blob#100 |> resize(100,100) |> sepia(1)

        public string GetPath() => GetFullName("/", prefix: Source.Key);

        public string GetFullName() => GetFullName("/");

        public string GetFullName(string transformSeperator, string prefix = null)
        {
            /* 
			10x10.gif			
			crop(0,0,10,10).jpeg
			10x10-c/rotate(90).png
			200x100/rotate(90).png
			640x480.mp4
			*/

            var sb = StringBuilderCache.Aquire();

            if (prefix != null)
            {
                sb.Append(prefix);
            }

            foreach (var transform in transforms)
            {
                if (transform is Encode encode)
                {
                    sb.Append('.');
                    sb.Append(encode.Format.ToString().ToLower());
                }
                else
                {
                    if (sb.Length != 0)
                    {
                        sb.Append(transformSeperator);
                    }

                    if (transform is ICanonicalizable canonicalizable)
                    {
                        canonicalizable.WriteTo(sb);
                    }
                    else
                    {
                        sb.Append(transform.ToString());
                    }
                }
            }

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        #endregion
    }
}