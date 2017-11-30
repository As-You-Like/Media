using System;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class VideoFrame : Frame
    {
        private byte_ptrArray4 planePointers;
        private int_array4 linesizes;

        public VideoFrame(PixelFormat format, int width, int height)
        {
            #region Preconditions

            if (width <= 0)
                throw new ArgumentException("Must be > 0", nameof(width));

            if (height <= 0)
                throw new ArgumentException("Must be > 0", nameof(height));

            #endregion

            Format = format;
            Width  = width;
            Height = height;

            pointer->format = (int)format.ToAVFormat();
            pointer->width  = width;
            pointer->height = height;

            pointer->extended_data = (byte**)(&pointer->data);

            var info = VideoFormatInfo.Create(format, width, height);

            Strides = info.Strides;

            Memory = Buffer.Allocate(info.BufferSize);

            // Fill the pointers
           
            planePointers = new byte_ptrArray4();
            linesizes = new int_array4();

            ffmpeg.av_image_fill_arrays(
                ref planePointers,
                ref linesizes,
                (byte*)Memory.Pointer,
                format.ToAVFormat(),
                width,
                height,
                1           // align = 8 ?
            );


            /*
            ffmpeg.av_image_fill_pointers(
                data      : ref planeArray,                     // pointers array to be filled with the pointer for each image plane
                pix_fmt   : (AVPixelFormat)pointer->format,        
                height    : Height,
                ptr       : (byte*)Memory.Pointer,              // the pointer to a buffer which will contain the image
                linesizes : GetStridesArray()
            );
            */
        }

        public void Update(IntPtr planeData, int planeIndex = 0)
        {
            if (planeIndex < 0 || planeIndex >= Strides.Length)
            {
                throw new ArgumentOutOfRangeException("out of range");
            }

            var bytewidth = ffmpeg.av_image_get_linesize((AVPixelFormat)pointer->format, Width, planeIndex);

            ffmpeg.av_image_copy_plane(
                dst          : PlaneDataPointers[(uint)planeIndex],
                dst_linesize : Strides[planeIndex],
                src          : (byte*)planeData,
                src_linesize : Strides[planeIndex],
                bytewidth    : bytewidth,
                height       : Height
            );
        }


        /*
        public void Sync()
        {
            // Sync with the plane pointers

            var planeArray = GetPlanesArray();
            var stridesArray = GetStridesArray();

            ffmpeg.av_image_copy(
                dst_data        : ref planeArray,
                dst_linesizes   : ref stridesArray,
                src_data        : pointer->extended_data,
                src_linesizes   : pointer->linesize,
                pix_fmt         : (AVPixelFormat)pointer->format,
                width: Width,
                height: Height

            );
            
        }
        */

        public PixelFormat Format { get; }

        public int Width { get; }

        public int Height { get; }

        /// <summary>
        /// The order the frame is encoded within the bitstream (coded picture number)
        /// </summary>
        public long CodedIndex => pointer->coded_picture_number;

        /// <summary>
        /// The order the frame is presented (e.g. display picture number)
        /// </summary>
        public long PresentationIndex => pointer->display_picture_number;

        public Rational? AspectRatio { get; set; }

        // public ColorSpace ColorSpace { get; set; }

        /// <summary>
        /// The length (size) of each picture line (plane?)
        /// </summary>
        public int[] Strides { get; }

        public int_array4 LineSizes => linesizes;

        // Pointers to the individual planes
        public byte_ptrArray4 PlaneDataPointers => planePointers;

        public PictureType PictureType => (PictureType)pointer->pict_type;
        
        // MotionVectors

        // IsInterlaced

        // IsKeyFrame
    }

    /*
    public class Plane
    {
        public IntPtr Pointer { get; set; }

        public int Stride { get; set; }
    }
    */
}