using System;
using System.Text;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public class FFmpegException : Exception
    {
        private static readonly byte[] nullTerminator = new byte[1] { 0 };

        public FFmpegException(int code)
            : this(GetMessage(code) + ":" + code)
        {
            Code = code;
        }

        public FFmpegException(string message)
            : base(message) { }

        public int Code { get; }

        public static unsafe string GetMessage(int code)
        {
            Span<byte> errorBytes = stackalloc byte[1024];

            fixed (byte* errorBytesPointer = errorBytes)
            {
                ffmpeg.av_strerror(code, errorBytesPointer, (ulong)errorBytes.Length);
            }

            int nullTerminatorIndex = errorBytes.IndexOf(nullTerminator);

            return Encoding.UTF8.GetString(errorBytes.Slice(0, nullTerminatorIndex));

            return result;
        }
    }
}