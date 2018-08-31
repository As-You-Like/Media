using System;
using Xunit;

namespace Carbon.Media.Processing.Tests
{

    public class VideoFrameTests
    {
        [Fact]
        public unsafe void StridesAndLineSizesAreEqual()
        {
            using (var frame = new VideoFrame(PixelFormat.Bgr24, 300, 300, align: 8))
            {
              
                Assert.Equal(new int[] { 904 }, frame.Strides); // rows aligned to nearest 8th byte


                Assert.Equal(new int[] { 904, 0, 0, 0, 0, 0, 0, 0 }, frame.Pointer->linesize);

                // var a = new Span<int>(&frame.Pointer->linesize, 8);
                // var b = new Span<long>(&frame.Pointer->data, 8);
                // 
                // throw new Exception(string.Join(",", b.ToArray()));

            }
        }

        [Fact]
        public unsafe void PaddedRowTest()
        {
            using (var frame = new VideoFrame(PixelFormat.Bgr24, 300, 300, align: 8))
            {
                Assert.Equal(300, frame.Width);
                Assert.Equal(300, frame.Height);
                Assert.Equal(PixelFormat.Bgr24, frame.Format);
                Assert.Equal(new int[] { 904 }, frame.Strides); // rows aligned to nearest 8th byte

                Assert.Equal(271200, frame.Memory.Length);               
            }
        }

        [Fact]
        public unsafe void A()
        {
            using (var frame = new VideoFrame(PixelFormat.Bgra32, 100, 100))
            {
                Assert.Equal(100, frame.Width);
                Assert.Equal(100, frame.Height);
                Assert.Equal(PixelFormat.Bgra32, frame.Format);
                Assert.Equal(new int[] { 400 }, frame.Strides);

                Assert.Equal(100 * 100 * 4, frame.Memory.Length);


                var b = new Span<IntPtr>(&frame.Pointer->data, 8);


                var planePointers = frame.PlanePointers.ToArray();

                Assert.Equal((IntPtr)planePointers[0], frame.Memory.Pointer);
                Assert.Equal(IntPtr.Zero, (IntPtr)planePointers[1]);
                Assert.Equal(IntPtr.Zero, (IntPtr)planePointers[2]);
                Assert.Equal(IntPtr.Zero, (IntPtr)planePointers[3]);

                Assert.Equal(b[0], (IntPtr)planePointers[0]);
            }
        }

        [Fact]
        public unsafe void B()
        {
            using (var frame = new VideoFrame(PixelFormat.Yuv420p, 640, 480))
            {
                Assert.Equal(640, frame.Width);
                Assert.Equal(480, frame.Height);
                Assert.Equal(PixelFormat.Yuv420p, frame.Format);

                Assert.Equal(new int[] { 640, 320, 320 }, frame.Strides);

                Assert.Equal(460800, frame.Memory.Length);

                var planePointers = frame.PlanePointers.ToArray();

                long p1 = (long)(IntPtr)planePointers[0];
                long p2 = (long)(IntPtr)planePointers[1];
                long p3 = (long)(IntPtr)planePointers[2];

                Assert.Equal((IntPtr)planePointers[0], frame.Memory.Pointer);
                Assert.Equal(307200, (p2 - p1)); // + 307200
                Assert.Equal(384000, (p3 - p1)); // + 384000
                Assert.Equal(IntPtr.Zero, (IntPtr)planePointers[3]);
            }
        }

        [Fact]
        public unsafe void Nv16()
        {
            using (var frame = new VideoFrame(PixelFormat.Nv16, 640, 480))
            {
                Assert.Equal(640, frame.Width);
                Assert.Equal(480, frame.Height);
                Assert.Equal(PixelFormat.Nv16, frame.Format);

                Assert.Equal(new int[] { 640, 640 }, frame.Strides);
                // Assert.Equal(new int[] { 640, 640, 0, 0 }, frame.LineSizes);

                Assert.Equal(614400, frame.Memory.Length);             
            }
        }

        [Fact]
        public unsafe void Gbrap16le()
        {
            using (var frame = new VideoFrame(PixelFormat.Gbrap16le, 640, 480))
            {
                Assert.Equal(640, frame.Width);
                Assert.Equal(480, frame.Height);
                Assert.Equal(PixelFormat.Gbrap16le, frame.Format);

                Assert.Equal(new int[] { 1280, 1280, 1280, 1280 }, frame.Strides);
                // Assert.Equal(new int[] { 1280, 1280, 1280, 1280 }, frame.LineSizes);

                Assert.Equal(2457600, frame.Memory.Length);
            }
        }
    }
}