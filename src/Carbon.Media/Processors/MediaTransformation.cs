using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using Carbon.Geometry;

namespace Carbon.Media
{
    using Processors;
    
    public class MediaTransformation : ISize
    {
        protected readonly List<IProcessor> transforms = new List<IProcessor>();

        private int width;
        private int height;

        public MediaTransformation(IMediaSource source, ImageFormat format)
        {
            Source = source;
            Format = format.ToLower();

            width  = source.Width;
            height = source.Height;
        }

        public MediaTransformation(IMediaSource source, string format)
        {
            #region Preconditions

            if (source == null) throw new ArgumentNullException(nameof(source));
            if (format == null) throw new ArgumentNullException(nameof(format));

            #endregion

            Source = source;
            Format = format;

            this.width = source.Width;
            this.height = source.Height;
        }

        public MediaTransformation(IMediaSource source, ImageOrientation orientation, string format)
            : this(source, format)
        {
            Apply(orientation.GetTransforms());
        }

        public IMediaSource Source { get; }

        public string Format { get; }

        public int Width => width;

        public int Height => height;

        public Size Size => new Size(width, height);

        public IReadOnlyList<IProcessor> GetProcessors() => transforms.AsReadOnly();

        public MediaTransformation Apply(params IProcessor[] processors)
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

        private MediaTransformation Apply(IProcessor transform)
        {
            if (transform is Crop)
            {
                var crop = ((Crop)transform).GetRectangle(Size);

                width  = (int)crop.Width;
                height = (int)crop.Height;
            }
            else if (transform is Resize)
            {
                var resize = (Resize)transform;

                var newSize = resize.CalcuateSize(Size);

                width = newSize.Width;
                height = newSize.Height;
            }
            else if (transform is Scale)
            {
                var scale = (Scale)transform;

                width = scale.Width;
                height = scale.Height;
            }
            else if (transform is Rotate)
            {
                var rotate = (Rotate)transform;

                // Flip the height & width
                if (rotate.Angle == 90 || rotate.Angle == 270)
                {
                    var oldWidth = width;
                    var oldHeight = height;

                    width = oldHeight;
                    height = oldWidth;
                }
            }
            else if (transform is Pad)
            {
                var pad = (Pad)transform;

                width  += (pad.Left + pad.Right);
                height += (pad.Top + pad.Bottom);
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

        public MediaTransformation ApplyFilter(string name, int value)
        {
            Apply(new UnknownFilter(name, value.ToString()));

            return this;
        }

        public MediaTransformation ApplyFilter(string name, string value)
        {
            Apply(new UnknownFilter(name, value));

            return this;
        }

        #endregion

        #region Transform Helpers

        [IgnoreDataMember]
        public bool HasTransforms => transforms.Count > 0;

        #endregion

        #region Helpers

        public static MediaTransformation ParsePath(string path)
        {
            #region Preconditions

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            #endregion

            if (path[0] == '/')
            {
                path = path.Substring(1);
            }

            // 100/transform/transform.format

            int lastDotIndex = path.LastIndexOf('.');
            string format = null;

            if (lastDotIndex > 0)
            {
                format = path.Substring(lastDotIndex + 1);
                path   = path.Substring(0, lastDotIndex);
            }

            var parts = path.Split(Seperators.ForwardSlash);

            var id = parts[0];

            var processors = new IProcessor[parts.Length - 1];

            for (var i = 1; i < parts.Length; i++)
            {
                var segment = parts[i];

                IProcessor processor;

                if (char.IsDigit(segment[0]))
                {
                    if (segment.Contains(":"))
                    {
                        // 1:00

                        var time = TimeSpan.Parse(segment);

                        processor = new Clip(time, time);
                    }
                    else
                    {
                        processor = Processors.Resize.Parse(segment);
                    }
                }
                else
                {
                    // TODO: Remove colon once crop has been migrated to new syntax.

                    var transformName = segment.Split('(', ':')[0];

                    switch (transformName)
                    {
                        case "resize"     : processor = Processors.Resize.Parse(segment);       break;
                        case "scale"      : processor = Scale.Parse(segment);                   break;
                        case "crop"       : processor = Processors.Crop.Parse(segment);         break;
                        case "rotate"     : processor = Processors.Rotate.Parse(segment);       break;
                        case "flip"       : processor = Flip.Parse(segment);                    break;
                        case "pad"        : processor = Pad.Parse(segment);                     break;
                        
                        // Drawing                       
                        case "text"       : processor = Processors.DrawText.Parse(segment);     break;
                        case "overlay"    : processor = DrawColor.Parse(segment);               break;
                        case "gradient"   : processor = DrawGradient.Parse(segment);            break;

                        // filters
                        case "hueRotate"  : 
                        case "hue-rotate" : processor = HueRotateFilter.Parse(segment);         break;
                        case "saturate"   : processor = SaturateFilter.Parse(segment);          break;
                        case "sepia"      : processor = SepiaFilter.Parse(segment);             break;
                        case "brightness" : processor = BrightnessFilter.Parse(segment);        break;
                        case "grayscale"  : processor = GrayscaleFilter.Parse(segment);         break;
                        case "blur"       : processor = BlurFilter.Parse(segment);              break;
                        case "invert"     : processor = InvertFilter.Parse(segment);            break;
                        case "contrast"   : processor = ContrastFilter.Parse(segment);          break;
                        case "opacity"    : processor = OpacityFilter.Parse(segment);           break;
                        default           : processor = UnknownFilter.Parse(segment);           break;
                    }
                }

                processors[i - 1] = processor;
            }

            var rendition = new MediaTransformation(new MediaSource(id, 0, 0), format);

            rendition.Apply(processors);

            return rendition;
        }
        
        // blob#100 |> resize(100,100) |> sepia(1)

       
        public string GetPath() => 
            Source.Key + "/" + GetFullName("/");

        public string GetFullName() =>
            GetFullName("/");

        public string GetFullName(string seperator)
        {
            /* 
			10x10.gif			
			crop(0,0,10,10).jpeg	// A cropped image rendention (x=0,y=0,width=100,height=100)
			10x10-c/rotate(90).png	// A 10x10 image (anchored at it's center when resized) rotated 90 degrees
			200x100/rotate(90).png
			640x480.mp4
			*/

            var sb = new StringBuilder();

            foreach (var transform in transforms)
            {
                if (sb.Length != 0)
                {
                    sb.Append(seperator);
                }

                sb.Append(transform.ToString());
            }

            sb.Append(".");

            sb.Append(Format);

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

        public ImageOrientation? Orientation => null;

        public string Key { get; }

        public int Width { get; }

        public int Height { get; }
    }
}
