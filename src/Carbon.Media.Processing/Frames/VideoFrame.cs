using System;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class VideoFrame : Frame
    {
        private byte_ptrArray4 planePointers;

        public VideoFrame(VideoFormatInfo format)
            : this(format.PixelFormat, format.Width, format.Height) { }

        // align to 8 for improved vectorization

        public VideoFrame(PixelFormat pixelFormat, int width, int height, int align = 1)
        {
            if (pixelFormat == default)
                throw new ArgumentException("Must not be Unknown", nameof(pixelFormat));

            if (width <= 0)
                throw new ArgumentException("Must be > 0", nameof(width));

            if (height <= 0)
                throw new ArgumentException("Must be > 0", nameof(height));

            Format = pixelFormat;
            Width = width;
            Height = height;

            pointer->format = (int)pixelFormat.ToAVFormat();
            pointer->width = width;
            pointer->height = height;

            Memory = Buffer.Allocate(VideoFormatHelper.GetBufferSize(pixelFormat, width, height, align));

            // Fill the pointers

            planePointers = new byte_ptrArray4();

            var lineSizes = new int_array4();

            ffmpeg.av_image_fill_arrays(
                ref planePointers,
                ref lineSizes,
                src: (byte*)Memory.Pointer,
                pixelFormat.ToAVFormat(),
                width,
                height,
                align
            );

            Strides = GetStrides(lineSizes);

            pointer->data = From4(planePointers);
            pointer->linesize = From4(lineSizes);
        }

        private static int_array8 From4(int_array4 val)
        {
            return new int_array8
            {
                [0] = val[0],
                [1] = val[1],
                [2] = val[2],
                [3] = val[3]
            };
        }

        private static byte_ptrArray8 From4(byte_ptrArray4 val)
        {
            return new byte_ptrArray8
            {
                [0] = val[0],
                [1] = val[1],
                [2] = val[2],
                [3] = val[3]
            };
        }

        // returns an array of no zero values
        // e.g. { 100, 0, 0, 0 }
        private static int[] GetStrides(int[] lineSizes)
        {
            int nonZeroCount = 0;

            foreach (var lineSize in lineSizes)
            {
                if (lineSize != 0) nonZeroCount++;
            }

            var result = new int[nonZeroCount];

            lineSizes.AsSpan(0, nonZeroCount).CopyTo(result);

            return result;
        }

        /*
        public void Update(byte* planeData, int planeIndex = 0)
        {
            if (planeIndex < 0 || planeIndex >= Strides.Length)
            {
                throw new ArgumentOutOfRangeException("Invalid planeIndex:" + planeIndex);
            }

            var lineByteCount = ffmpeg.av_image_get_linesize((AVPixelFormat)pointer->format, Width, planeIndex);

            ffmpeg.av_image_copy_plane(
                dst: PlanePointers[(uint)planeIndex],
                dst_linesize: Strides[planeIndex],
                src: planeData,
                src_linesize: Strides[planeIndex],
                bytewidth: lineByteCount,
                height: Height
            );
        }
        */

        public PixelFormat Format { get; }

        public int Width { get; }

        public int Height { get; }

        // the length, in bytes, of each pixel line, in each plane
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

        // Pointers to the individual planes
        public byte_ptrArray4 PlanePointers => planePointers;

        public PictureType PictureType => (PictureType)pointer->pict_type;

        // MotionVectors

        // IsInterlaced

        // IsKeyFrame
    }
}