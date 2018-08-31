namespace Carbon.Media.Analysis.Internal
{
    public class ProbeResult
    {
        public ProbedStream[] Streams { get; set; }

        public ProbedFormat Format { get; set; }
        
        public FormatInfo ToFormatInfo()
        {
            var formatName = Format.FormatName;

            if (formatName.IndexOf(',') > -1)
            {
                formatName = formatName.Substring(0, formatName.IndexOf(','));
            }

            var ok = Mime.TryGetFromFormat(formatName, out var mime);

            var format = new FormatInfo
            {
                Type = ok ? mime.Name : "application/" + formatName,
                Format = formatName,
                Size = Format.Size,
                Duration = Format.Duration,
                Streams = new MediaStreamInfo[Streams.Length]                
            };

         
            for (var i = 0; i < Streams.Length; i++)
            {
                var stream = Streams[i].ToStreamInfo();

                format.Streams[i] = stream;

                if (stream.Type == MediaStreamType.Video)
                {
                    var videoStream = (VideoStreamInfo)stream;

                    format.Width = videoStream.Width;
                    format.Height = videoStream.Height;
                }
            }

            return format;

        }

    }
}


// SCHEMA
// https://raw.githubusercontent.com/FFmpeg/FFmpeg/master/doc/ffprobe.xsd
