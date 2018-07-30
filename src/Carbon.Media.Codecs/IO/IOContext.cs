using System;
using System.IO;
using FFmpeg.AutoGen;

namespace Carbon.Media.IO
{
    public unsafe sealed class IOContext : IDisposable
    {
        private bool isDisposed = false;

        private readonly Stream stream;

        // keep under 32K
        // https://ffmpeg.org/pipermail/libav-user/2013-April/004162.html

        const int bufferSize = 32768;

        private readonly byte* buffer;

        private readonly avio_alloc_context_read_packet read;
        private readonly avio_alloc_context_write_packet write;
        private readonly avio_alloc_context_seek seek;

        public IOContext(Stream stream, bool writable = false)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));

            ulong paddingLength = writable ? 0ul : ffmpeg.AV_INPUT_BUFFER_PADDING_SIZE; // reversed

            // note: this can be replaced...
            buffer = (byte*)ffmpeg.av_malloc(bufferSize + paddingLength);

            // reference to prevent garbage collection
            read = Read;
            write = Write;
            seek = Seek;

            Pointer = ffmpeg.avio_alloc_context(
                buffer: buffer,
                buffer_size: bufferSize,
                write_flag: writable ? 1 : 0,
                opaque: null,
                read_packet: read,
                write_packet: write,
                seek: seek
            );

            Pointer->seekable = ffmpeg.AVIO_SEEKABLE_NORMAL; //  | ffmpeg.AVIO_SEEKABLE_TIME;
        }

        internal AVIOContext* Pointer;

        int Write(void* opaque, byte* buf, int bufferSize)
        {
            var span = new ReadOnlySpan<byte>(buf, bufferSize);

            stream.Write(span);

            return bufferSize;
        }

        int Read(void* opaque, byte* buf, int bufferSize)
        {
            if (stream.Position >= stream.Length)
            {
                return ffmpeg.AVERROR_EOF;
            }

            var buffer = new Span<byte>(buf, bufferSize);

            int result = stream.Read(buffer);

            // Console.WriteLine("read" + " " + bufferSize + " / " + result + " | " + stream.Position);

            return result;

        }

        long Seek(void* opaque, long offset, int whence)
        {
            // Console.WriteLine("seek: " + offset + ":" + (SeekFlags)whence + "/" + (SeekOrigin)whence);

            if (whence == ffmpeg.AVSEEK_SIZE)
            {
                return stream.Length;
            }

            if (!stream.CanSeek)
            {
                // Console.WriteLine("cannot seek");

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
            if (isDisposed) return;

            // Console.WriteLine("Disposing IOContext");

            // NOTE: The internal buffer may have changed

            var a = (IntPtr)Pointer->buffer;
            var b = (IntPtr)buffer;

            if (a == b)
            {
                ffmpeg.av_free(buffer);
            }
            else
            {
                // ffmpeg.av_free(buffer);
                ffmpeg.av_free(&Pointer->buffer); // free the current buffer
            }

            fixed (AVIOContext** p = &Pointer)
            {
                ffmpeg.avio_context_free(p);
            }

            Pointer = null;

            isDisposed = true;
        }

        ~IOContext()
        {
            Dispose(false);
        }
    }
}