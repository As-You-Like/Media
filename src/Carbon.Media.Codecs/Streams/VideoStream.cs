using System;

using Carbon.Media.Codecs;
using Carbon.Media.Formats;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class VideoStream : MediaStream, IVideo
    {
        internal VideoStream(AVStream* pointer)
            : base(pointer) { }

        internal VideoStream(AVStream* pointer, Codec codec)
            : base(pointer, codec) { }

        public PixelFormat PixelFormat => Codec.Context.PixelFormat;

        // ColorSpace...

        /// <summary>
        /// The frame width
        /// </summary>
        public int Width => Codec.Context.Width;

        /// <summary>
        /// The frame height
        /// </summary>
        public int Height => Codec.Context.Height;

        /// <summary>
        /// The aspect ratio of the pixels when presented (displayed)
        /// </summary>
        public Rational AspectRatio
        {
            get
            {
                if (pointer->display_aspect_ratio.den == 0 || pointer->display_aspect_ratio.IsUnknown() )
                {
                    Console.WriteLine("invalid aspect ratio");

                    return new Rational(1, 1);
                }

                return pointer->display_aspect_ratio.ToRational();
            }
        }

        // public ExifOrientation? Orientation { get; set; }

        public override MediaStreamType Type => MediaStreamType.Video;

        #region IVideo

        ICodec IVideo.Codec => Codec;

        TimeSpan? IVideo.Duration => base.Duration?.TimeSpan;

        #endregion

        public static VideoStream Create(Format format, Codec codec)
        {
            if (format is null)
                throw new ArgumentNullException(nameof(format));

            if (codec is null)
                throw new ArgumentNullException(nameof(codec));

            AVStream* pointer = ffmpeg.avformat_new_stream(format.Context.Pointer, codec.Pointer);

            return new VideoStream(pointer, codec);
        }
    }
}