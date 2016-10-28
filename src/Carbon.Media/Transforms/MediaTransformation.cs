using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media
{
    using Geometry;

    public class MediaTransformation : ISize
    {
        protected readonly IMediaSource source;
        protected readonly string format;
        protected readonly List<ITransform> transforms = new List<ITransform>();

        private int width;
        private int height;

        public MediaTransformation(IMediaSource source, string format)
        {
            #region Preconditions

            if (source == null) throw new ArgumentNullException(nameof(source));
            if (format == null) throw new ArgumentNullException(nameof(format));

            #endregion

            this.source = source;
            this.format = format;

            this.width = source.Width;
            this.height = source.Height;
        }

        public MediaTransformation(IMediaSource source, MediaOrientation orientation, string format)
            : this(source, format)
        {
            Transform(orientation.GetTransforms());
        }

        public IMediaSource Source => source;

        public string Format => format;

        public int Width => width;

        public int Height => height;

        // TODO: Immutable
        public IList<ITransform> GetTransforms() => transforms.AsReadOnly();

        public MediaTransformation Transform(params ITransform[] transformList)
        {
            #region Preconditions

            if (transformList == null) throw new ArgumentNullException("transformList");

            #endregion

            if (transformList.Length == 0) return this;

            foreach (var transform in transformList)
            {
                #region Update the Current Size

                if (transform is AnchoredResize)
                {
                    var anchoredResize = (AnchoredResize)transform;

                    width = anchoredResize.Width;
                    height = anchoredResize.Height;
                }
                else if (transform is Resize)
                {
                    var resize = (Resize)transform;

                    width = resize.Width;
                    height = resize.Height;
                }
                else if (transform is Crop)
                {
                    var crop = (Crop)transform;

                    this.width = crop.Width;
                    this.height = crop.Height;
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

                #endregion

                this.transforms.Add(transform);
            }

            return this;
        }

        #region Builders

        public MediaTransformation Rotate(int angle)
        {
            Transform(new Rotate(angle));

            return this;
        }

        public MediaTransformation Crop(Rectangle rect)
        {
            Transform(new Crop(rect));

            return this;
        }


        public MediaTransformation Clip(TimeSpan start, TimeSpan end)
        {
            Transform(new Clip(start, end));

            return this;
        }

        public MediaTransformation Crop(int x, int y, int width, int height)
        {
            Transform(new Crop(x, y, width, height));

            return this;
        }

        public MediaTransformation Resize(int width, int height)
        {
            Transform(new Resize(width, height));

            return this;
        }

        public MediaTransformation ApplyFilter(string name, int value)
        {
            Transform(new ApplyFilter(name, value.ToString()));

            return this;
        }

        public MediaTransformation ApplyFilter(string name, string value)
        {
            Transform(new ApplyFilter(name, value));

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
            // 100/transform/transform.format

            var lastDotIndex = path.LastIndexOf('.');
            var format = (lastDotIndex > 0) ? path.Substring(lastDotIndex + 1) : null;

            if (lastDotIndex > 0)
            {
                path = path.Substring(0, lastDotIndex);
            }

            var parts = path.TrimStart('/').Split('/');

            int i = 1;

            string id = "";
            var transforms = new List<ITransform>();

            foreach (var part in parts)
            {
                if (i == 1)
                {
                    id = part;
                }
                else
                {
                    ITransform transform;


                    if (char.IsDigit(part[0]))
                    {

                        if (part.Contains("-"))
                        {
                            transform = AnchoredResize.Parse(part);
                        }
                        else if (part.Contains(":"))
                        {
                            // 1:00

                            var time = TimeSpan.Parse(part);

                            transform = new Clip(time, time);
                        }
                        else
                        {
                            transform = Media.Resize.Parse(part);
                        }
                    }
                    else
                    {
                        var transformName = part.Split('(', ':')[0];

                        switch (transformName)
                        {
                            case "crop"   : transform = Media.Crop.Parse(part);        break;
                            case "rotate" : transform = Media.Rotate.Parse(part);      break;
                            case "flip"   : transform = Flip.Parse(part);              break;
                            default       : transform = Media.ApplyFilter.Parse(part); break;
                        }
                    }

                    transforms.Add(transform);
                }

                i++;
            }

            var rendition = new MediaTransformation(new MediaSource(id), format);

            foreach (var t in transforms)
            {
                rendition.Transform(t);
            }

            return rendition;
        }

        public string GetPath()
        {
            return source.Key + "/" + GetFullName();
        }

        public string GetFullName()
        {
            /* 
			10x10.gif			
			crop:0-0_10x10.jpeg		// A cropped image rendention (x=0,y=0,width=100,height=100)
			10x10-c/rotate(90).png	// A 10x10 image (anchored at it's center when resized) rotated 90 degrees
			200x100/rotate(90).png
			640x480.mp4
			*/

            var sb = new StringBuilder();

            foreach (var transform in transforms)
            {
                if (sb.Length != 0)
                {
                    sb.Append("/");
                }

                sb.Append(transform.ToString());
            }

            sb.Append(".");

            sb.Append(format);

            return sb.ToString();
        }

        #endregion
    }

    internal class MediaSource : IMediaSource
    {
        public MediaSource(string key)
        {
            Key = key;
        }

        public string Key { get; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
