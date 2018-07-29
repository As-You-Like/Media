using System;

using Carbon.Media.Codecs;
using Carbon.Media.Formats;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class VideoStream : MediaStream, IVideo
    {
        public VideoStream(AVStream* pointer)
            : base(pointer) { }

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
        public Rational AspectRatio => pointer->display_aspect_ratio.ToRational();
        
        // public ExifOrientation? Orientation { get; set; }
        
        public override MediaType Type => MediaType.Video;

        #region IVideo

        ICodec IVideo.Codec => Codec;

        TimeSpan? IVideo.Duration => base.Duration?.TimeSpan;

        #endregion
        
        public static VideoStream Create(Format format, Codec codec)
        {
            if (format == null)
                throw new ArgumentNullException(nameof(format));

            if (codec == null)
                throw new ArgumentNullException(nameof(codec));

            AVStream* stream = ffmpeg.avformat_new_stream(format.Context.Pointer, codec.Pointer);
            
            stream->codec = codec.Context.Pointer;

            return new VideoStream(stream);
        }
    }
}