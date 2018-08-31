using System.Text;

namespace Carbon.Media.Processing
{
    public class StabilizeFilter : IFilter
    {
        public string Canonicalize() => "stabilize";
        
        public void WriteTo(StringBuilder sb)
        {
            sb.Append("stabilize");
        }
    }

    // deshake in ffmpeg
}