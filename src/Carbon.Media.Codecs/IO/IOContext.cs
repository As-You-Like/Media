using System;
using System.IO;
using System.Runtime.InteropServices;

using FFmpeg.AutoGen;

namespace Carbon.Media.IO
{
    public unsafe sealed class IOContext : IDisposable
    {
        private readonly Stream stream;

        const int defaultBufferSize = 16384 * 2;
        readonly byte* buffer;

        private readonly byte[] temp = new byte[defaultBufferSize];

        public IOContext(Stream stream, bool writable = false)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));

            ulong paddingLength = writable ? 0ul : ffmpeg.AV_INPUT_BUFFER_PADDING_SIZE;

            buffer = (byte*)ffmpeg.av_malloc(defaultBufferSize + paddingLength);

            Pointer = ffmpeg.avio_alloc_context(
                buffer       : buffer,
                buffer_size  : defaultBufferSize,
                write_flag   : writable ? 1 : 0,
                opaque       : null,
                read_packet  : (avio_alloc_context_read_packet)Read,
                write_packet : (avio_alloc_context_write_packet)Write,
                seek         : (avio_alloc_context_seek)Seek
            );
            
            Pointer->seekable = ffmpeg.AVIO_SEEKABLE_NORMAL | ffmpeg.AVIO_SEEKABLE_TIME;
        }

        internal AVIOContext* Pointer;

        int Write(void* opaque, byte* buf, int bufferSize)
        {
            // Console.WriteLine("write" + " " + bufferSize);

            Marshal.Copy((IntPtr)buf, temp, 0, bufferSize);

            stream.Write(temp, 0, bufferSize);

            // Console.WriteLine("-written");

            return bufferSize;
        }

        int Read(void* opaque, byte* buf, int bufferSize)
        {
            // Console.Write("read" + " " + bufferSize);

            // Console.WriteLine(bufferSize + "/" + defaultBufferSize);

            int read = stream.Read(temp.AsSpan(0, bufferSize));

            Marshal.Copy(temp, 0, (IntPtr)buf, read);

            return read;
        }

        long Seek(void* opaque, long offset, int whence)
        {
            Console.WriteLine("seek:" + whence);

            Console.WriteLine((SeekFlags)whence + "/" + (SeekOrigin)whence);

            if (whence == ffmpeg.AVSEEK_SIZE)
            {
                return stream.Length;
            }

            if (!stream.CanSeek)
            {
                return -1;
            }

            stream.Seek(offset, (SeekOrigin)whence);

            return stream.Position;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            Console.WriteLine("Disposing IOContext");

            if (Pointer != null)
            {
                ffmpeg.av_freep(&Pointer->buffer);

                fixed (AVIOContext** p = &Pointer)
                {
                    ffmpeg.avio_context_free(p);
                }

                Pointer = null;
            }
        }

        ~IOContext()
        {
            Dispose(false);
        }
    }
}