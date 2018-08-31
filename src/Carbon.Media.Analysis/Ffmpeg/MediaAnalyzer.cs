using System;
using Carbon.Json;
using Carbon.Media.Analysis.Internal;

namespace Carbon.Media.Analysis
{
    public class MediaAnalyzer
    {
        private readonly Ffprobe probe = new Ffprobe();
        
        public FormatInfo Analyze(Uri url)
        {
            if (url is null)
                throw new ArgumentNullException(nameof(url));

            var result = probe.Get(url.ToString());
            
            try
            {
                var r = JsonObject.Parse(result).As<ProbeResult>();

                return r.ToFormatInfo();
            }
            catch
            {
                throw new Exception(result);
            }
        }
    }
}
