using System;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class VideoFrame : Frame
    {
        private byte_ptrArray4 planePointers;
        private int_array4 linesizes;

        public VideoFrame(VideoFormatInfo format)
            : this(format.PixelFormat, format.Width, format.Height) { }

        public VideoFrame(PixelFormat pixelFormat, int width, int height)
        {
            if (pixelFormat == default) throw new ArgumentException("Must not be Unknown", nameof(pixelFormat));
            if (width <= 0) throw new ArgumentException("Must be > 0", nameof(width));
            if (height <= 0) throw new ArgumentException("Must be > 0", nameof(height));

            Format = pixelFormat;
            Width  = width;
            Height = height;

            pointer->format = (int)pixelFormat.ToAVFormat();
            pointer->width  = width;
            pointer->height = height;

            pointer->extended_data = (byte**)(&pointer->data);

            var format = new VideoFormatInfo(pixelFormat, width, height);

            const int align = 8;

            Strides = format.GetStrides(align); 
            Memory  = Buffer.Allocate(format.GetBufferSize(align));

            // Fill the pointers
           
            planePointers = new byte_ptrArray4();
            linesizes = new int_array4();

            ffmpeg.av_image_fill_arrays(
                ref planePointers,
                ref linesizes,
                (byte*)Memory.Pointer,
                pixelFormat.ToAVFormat(),
                width,
                height,
                align
            );
        }

        public void Update(byte* planeData, int planeIndex = 0)
        {
            if (planeIndex < 0 || planeIndex >= Strides.Length)
            {
                throw new ArgumentOutOfRangeException("out of range");
            }

            var lineByteCount = ffmpeg.av_image_get_linesize((AVPixelFormat)pointer->format, Width, planeIndex);

            ffmpeg.av_image_copy_plane(
                dst          : planePointers[(uint)planeIndex],
                dst_linesize : Strides[planeIndex],
                src          : planeData,
                src_linesize : Strides[planeIndex],
                bytewidth    : lineByteCount,
                height       : Height
            );
        }

        public PixelFormat Format { get; }

        public int Width { get; }

        public int Height { get; }

        public int[] Strides { get; }

        /// <summary>
        /// The order the frame is encoded within the bitstream (coded picture number)
        /// </summary>
        public long CodedIndex => pointer->coded_picture_number;

        /// <summary>
        /// The order the frame is presented
        /// </summary>
        public long PresentationIndex => pointer->display_picture_number;

        public Rational? AspectRatio
        {
            get
            {
                if (pointer->sample_aspect_ratio.IsUnknown())
                {
                    return null;
                }

                return pointer->sample_aspect_ratio.ToRational();
            }

            set => pointer->sample_aspect_ratio = value.ToAVRational();
        }

        public AVColorSpace ColorSpace
        {
            get => pointer->colorspace;
            // set => pointer->colorspace = value;
        }

        /// <summary>
        /// The length (size) of each picture line (plane?)
        /// </summary>
        // public int[] Strides { get; }

        // public int_array4 LineSizes => linesizes;

        // Pointers to the individual planes
        public byte_ptrArray4 PlaneDataPointers => planePointers;

        public PictureType PictureType => (PictureType)pointer->pict_type;
        
        // MotionVectors

        // IsInterlaced

        // IsKeyFrame
    }
}