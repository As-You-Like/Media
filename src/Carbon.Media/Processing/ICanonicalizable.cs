using System.Text;

namespace Carbon.Media.Processing
{
    internal interface ICanonicalizable
    {
        void WriteTo(StringBuilder sb);
    }
}