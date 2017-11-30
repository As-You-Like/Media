using System;
using System.IO;

using Carbon.Media.IO;
using FFmpeg.AutoGen;

namespace Carbon.Media.Formats
{
    /// <summary>
    /// Demuxers split a media file into packets
    /// </summary>
    public unsafe class Demuxer : Format
    {
        public Demuxer(FormatId format)
            : base(format) { }

        public Demuxer(FormatContext context)
            : base(context) { }

        public bool IsEof { get; private set; }

        public override FormatType Type => FormatType.Demuxer;

        private readonly Packet tempPacket = Packet.Allocate();

        // Packets are either Video or Audio data
        public bool TryReadPacket(out Packet packet)
        {
            if (IsEof) throw new EndOfStreamException("Cannot read past the end of stream");

            int result = ffmpeg.av_read_frame(Context.Pointer, tempPacket.Pointer);

            if (result == 0)
            {
                var outputStream = Context.Streams[tempPacket.StreamIndex];

                tempPacket.TimeBase = outputStream.TimeBase; // set the timebase

                packet = tempPacket;

                return true;
            }
            
            // 0 if OK, < 0 on error or end of file
            
            if (result == -541478725) // EOF
            {
                IsEof = true;

                packet = default;

                return false;
            }
            
            throw new FFmpegException(result);            
        }

        public void Seek(long position)
        {

        }

        public static Demuxer Open(Uri url)
        {
            var context = new FormatContext();

            context.Open(url);

            return new Demuxer(context);
        }

        public static Demuxer Open(IOContext source)
        {
            var context = new FormatContext();

            context.Open(source);

            return new Demuxer(context);
        }

        public override void Cleanup()
        {
            tempPacket?.Dispose();
        }
    }
}
