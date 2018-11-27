using System;
using Carbon.Json;
using Carbon.Media.Analysis.Internal;

namespace Carbon.Media.Analysis
{
    public class MediaAnalyzer
    {
        private static readonly Ffprobe probe = new Ffprobe();
        
        public FormatInfo Analyze(Uri url)
        {
            if (url is null)
                throw new ArgumentNullException(nameof(url));

            string result = probe.Get(url.ToString());

            if (result[0] != '{')
            {
                throw new Exception("Expected JSON. Was " + result);
            }

            var json = JsonObject.Parse(result);

            // Check for errors
            if (json.TryGetValue("error", out JsonNode errorNode))
            {
                throw new AnalyzeException(errorNode.As<AnalyzeError>());
            }

            try
            {
                return json.As<ProbeResult>().ToFormatInfo();
            }
            catch
            {
                throw new Exception("error converting JSON to FormatInfo:" + result);
            }
        }
    }
}
