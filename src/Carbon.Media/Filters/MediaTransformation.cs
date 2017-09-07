using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media
{
    using Processors;
    
    public class MediaTransformation
    {
        protected readonly List<ITransform> transforms = new List<ITransform>();

        private int width;
        private int height;
        private ImageEncode encoder;

        public MediaTransformation(IMediaSource source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            
            width  = source.Width;
            height = source.Height;

            if (source.Orientation != null)
            {
                Apply(source.Orientation.Value.GetTransforms());
            }
        }

        public IMediaSource Source { get; }

        public int Width => width;

        public int Height => height;

        public ImageEncode Encoder => encoder;

        public ImageFormat Format => encoder.Format;

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
            else if (transform is ImageEncode encode)
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

        public MediaTransformation DrawText(string text)
        {
            Apply(new DrawText(text, new UnboundBox()));

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
            Apply(new Background(color));

            return this;
        }

        public MediaTransformation WithPage(int number)
        {
            Apply(new Page(number));

            return this;
        }

        public MediaTransformation WithColorSpace(ColorSpace colorSpace)
        {
            Apply(new ColorSpaceFilter(colorSpace));

            return this;
        }

        public MediaTransformation Blur(int value)
        {
            Apply(new BlurFilter(value));

            return this;
        }

        public MediaTransformation Encode(ImageFormat format, int? quality = null)
        {
            if (encoder != null)
            {
                throw new Exception("An encoder has already been set");
            }

            encoder = new ImageEncode(format, quality);

            Apply(encoder);

            return this;
        }

        #endregion

        #region Helpers

        [IgnoreDataMember]
        public bool HasTransforms => transforms.Count > 0;

        public static MediaTransformation ParsePath(string path)
        {
            #region Preconditions

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (path.Length < 3)
            {
                throw new ArgumentException("May not be empty", nameof(path));
            }

            #endregion

            if (path.StartsWith("/"))
            {
                path = path.Substring(1);
            }

            // 100/{transform}.{format}

            int lastDotIndex        = path.LastIndexOf('.');
            int firstSeperatorIndex = path.IndexOf('/');

            if (lastDotIndex == -1)
            {
                throw new Exception("no format provided");
            }
           
            string id              = path.Substring(0, firstSeperatorIndex);
            string transformString = path.Substring(firstSeperatorIndex, lastDotIndex - firstSeperatorIndex);
            string format          = path.Substring(lastDotIndex + 1);

            var segments = transformString.Split(Seperators.ForwardSlash);

            var transforms = ParseTransforms(segments);

            var source = new MediaSource(id, 0, 0);

            var rendition = new MediaTransformation(source)
                .Apply(transforms)
                .Encode(ImageFormatHelper.Parse(format));

            return rendition;
        }

        public static ITransform[] ParseTransforms(string[] segments)
        {
            var transforms = new ITransform[segments.Length - 1];

            for (var i = 1; i < segments.Length; i++)
            {
                var segment = segments[i];

                ITransform transform;

                if (char.IsDigit(segment[0]))
                {
                    // 1:00
                    if (segment.Contains(":"))
                    {
                        var time = TimeSpan.Parse(segment);

                        transform = new Clip(time, time);
                    }
                    else
                    {
                        transform = Processors.Resize.Parse(segment);
                    }
                }
                else
                {
                    transform = Transform.Parse(segment);
                }

                transforms[i - 1] = transform;
            }

            return transforms;
        }

        // blob#100 |> resize(100,100) |> sepia(1)

        public string GetPath() => GetFullName("/", prefix: Source.Key);

        public string GetFullName() => GetFullName("/");

        public string GetFullName(string seperator, string prefix = null)
        {
            /* 
			10x10.gif			
			crop(0,0,10,10).jpeg
			10x10-c/rotate(90).png
			200x100/rotate(90).png
			640x480.mp4
			*/

            var sb = new StringBuilder();

            if (prefix != null)
            {
                sb.Append(prefix);
            }

            foreach (var transform in transforms)
            {
                if (transform is ImageEncode encode)
                {
                    sb.Append("." + encode.Format.ToLower());
                }
                else
                {
                    if (sb.Length != 0)
                    {
                        sb.Append(seperator);
                    }

                    sb.Append(transform.ToString());
                }
            }

            return sb.ToString();
        }

        #endregion
    }

    internal class MediaSource : IMediaSource
    {
        public MediaSource(string key, int width, int height)
        {
            Key = key;
            Width = width;
            Height = height;
        }

        public ExifOrientation? Orientation => null;

        public string Key { get; }

        public int Width { get; }

        public int Height { get; }
    }
}