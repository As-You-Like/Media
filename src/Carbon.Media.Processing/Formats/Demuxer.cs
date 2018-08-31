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

        // Packets are either Video or Audio data
        public bool TryReadPacket(Packet packet)
        {
            if (IsEof)
            {
                throw new EndOfStreamException("Cannot read past the end of stream");
            }
            
            packet.Unref(); // unref any existing references so it may be reused for the next read

            int result = ffmpeg.av_read_frame(Context.Pointer, packet.Pointer);

            if (result == 0) // OK
            {
                // AVPacket.pts, AVPacket.dts and AVPacket.duration timing information will be set if known.
                // They may also be unset (i.e. AV_NOPTS_VALUE for pts/dts, 0 for duration) if the stream does not provide them.
                // The timing information will be in AVStream.time_base units, 
                // i.e. it has to be multiplied by the timebase to convert them to seconds.

                MediaStream outputStream = Context.Streams[packet.StreamIndex];
                
                // tempPacket.TimeBase = outputStream.TimeBase; // set the timebase

                // TODO: Update timestamp

                return true;
            }
                        
            else if (result == -541478725) // EOF
            {
                IsEof = true;

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

        public static Demuxer Open(FileInfo file)
        {
            var context = new FormatContext();

            context.Open(file);

            return new Demuxer(context);
        }

        public static Demuxer Open(Stream stream)
        {
            return Open(new IOContext(stream));
        }

        public static Demuxer Open(IOContext source)
        {
            var context = new FormatContext();

            context.Open(source);

            return new Demuxer(context) { ioContext = source };
        }
    }
}
