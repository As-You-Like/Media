using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

using Carbon.Media.Processing;

namespace Carbon.Media
{
    using Drawing;

    public class MediaTransformation
    {
        protected readonly List<IProcessor> processors = new List<IProcessor>();

        private int width;
        private int height;
        private EncodeParameters encoder;

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

        public EncodeParameters Encoder => encoder;

        public FormatId Format => encoder.Format;

        public Size Size => new Size(width, height);
     
        public IProcessor this[int index] => processors[index];

        public IReadOnlyList<IProcessor> GetTransforms() => processors;

        public MediaTransformation Apply(params IProcessor[] processors)
        {
            if (processors is null)
            {
                throw new ArgumentNullException(nameof(processors));
            }

            if (processors.Length == 0) return this;

            foreach (var processor in processors)
            {
                Apply(processor);
            }

            return this;
        }

        private MediaTransformation Apply(IProcessor transform)
        {
            if (transform is CropTransform crop)
            {
                var rect = crop.GetRectangle(Size);

                width = rect.Width;
                height = rect.Height;
            }
            else if (transform is ResizeTransform resize)
            {
                var newSize = resize.CalcuateSize(Size);

                width = newSize.Width;
                height = newSize.Height;
            }
            else if (transform is ScaleTransform scale)
            {
                width = scale.Width;
                height = scale.Height;
            }
            else if (transform is RotateTransform rotate)
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
            else if (transform is PadTransform pad)
            {
                width += (pad.Left + pad.Right);
                height += (pad.Top + pad.Bottom);
            }
            else if (transform is EncodeParameters encode)
            {
                encoder = encode;
            }

            this.processors.Add(transform);

            return this;
        }

        #region Builders

        public MediaTransformation Rotate(int angle)
        {
            Apply(new RotateTransform(angle));

            return this;
        }

        public MediaTransformation Crop(Rectangle rect)
        {
            Apply(new CropTransform(rect));

            return this;
        }

        public MediaTransformation Clip(TimeSpan start, TimeSpan end)
        {
            Apply(new ClipTransform(start, end));

            return this;
        }

        public MediaTransformation Draw(DrawCommand command)
        {
            Apply(command);

            return this;
        }

        public MediaTransformation Crop(int x, int y, int width, int height)
        {
            Apply(new CropTransform(x, y, width, height));

            return this;
        }

        public MediaTransformation Resize(int width, int height, CropAnchor anchor)
        {
            Apply(new ResizeTransform(new Size(width, height), anchor));

            return this;
        }

        public MediaTransformation Resize(in Unit width, in Unit height)
        {
            Apply(new ResizeTransform(width, height, ResizeFlags.Exact));

            return this;
        }

        public MediaTransformation Resize(int width, int height)
        {
            Apply(new ResizeTransform(width, height));

            return this;
        }

        public MediaTransformation WithQuality(int value)
        {
            Apply(new QualityFilter(value));

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
      
        public MediaTransformation Encode(FormatId format, int? quality = null)
        {
            if (encoder != null)
            {
                throw new Exception("An encoder has already been set");
            }

            encoder = new EncodeParameters(format, quality);

            Apply(encoder);

            return this;
        }

        #endregion

        #region Helpers

        [IgnoreDataMember]
        public bool HasTransforms => processors.Count > 0;

        public static MediaTransformation Parse(string path, IMediaInfo source = null)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            if (path.Length < 3)
                throw new ArgumentException("May not be empty", nameof(path));

            if (path[0] == '/')
            {
                path = path.Substring(1);
            }

            // {sourcePath}/{transform}.{format}

            int lastDotIndex   = path.LastIndexOf('.');
            int seperatorIndex = path.IndexOf(';');

            if (lastDotIndex == -1)
            {
                throw new InvalidTransformException(-1, "Must end with a format");
            }
           
            string sourcePath    = seperatorIndex > -1 ? path.Substring(0, seperatorIndex) : null;
            string transformPath = seperatorIndex > -1 ? path.Substring(seperatorIndex + 1, lastDotIndex - (seperatorIndex + 1)) : path.Substring(0, lastDotIndex);
            string format        = path.Substring(lastDotIndex + 1);

            string[] segments = transformPath.Split(Seperators.ForwardSlash);

            var transforms = ParseTransforms(segments);

            var rendition = new MediaTransformation(source ?? new MediaInfo(sourcePath, 0, 0))
                .Apply(transforms)
                .Encode(FormatIdExtensions.Parse(format), null);

            return rendition;
        }
        
        public static IProcessor[] ParseTransforms(string[] segments)
        {
            var transforms = new IProcessor[segments.Length];

            for (int i = 0; i < segments.Length; i++)
            {
                string segment = segments[i];

                if (segment.Length == 0) throw new InvalidTransformException(i, "May not be empty");

                IProcessor transform;

                try
                {
                    // 100x100 || 1000kbs || 1mbs
                    
                    if (char.IsDigit(segment[0]))
                    {
                        if (segment.EndsWith("bs")) // kbs | mbs
                        {
                            transform = BitRateFilter.Create(new CallSyntax("bitrate", new[] { new Argument(segment) }));
                        }
                        else
                        {
                            transform = ResizeTransform.Parse(segment);
                        }
                    }
                    else
                    {
                        transform = Processor.Parse(segment);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidTransformException(i, ex.Message, ex) { Text = segment };
                }

                transforms[i] = transform;
            }

            return transforms;
        }

        // blob#100 |> resize(100,100) |> sepia(1)

        public string GetTransformPath()
        {
            /* 
			10x10.gif			
			crop(0,0,10,10).jpeg
			10x10-c/rotate(90).png
			200x100/rotate(90).png
			640x480.mp4
			*/

            var sb = StringBuilderCache.Aquire();

            foreach (var transform in processors)
            {
                if (transform is EncodeParameters encode)
                {
                    sb.Append('.');
                    sb.Append(encode.Format.ToString().ToLower());
                }
                else
                {
                    if (sb.Length != 0)
                    {
                        sb.Append('/');
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

        public Pipeline ToPipeline() => Pipeline.From(this);

        #endregion
    }
}