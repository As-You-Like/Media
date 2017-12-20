using System.Text;

namespace Carbon.Media.Processors
{
    internal interface ICanonicalizable
    {
        void WriteTo(StringBuilder sb);
    }
}