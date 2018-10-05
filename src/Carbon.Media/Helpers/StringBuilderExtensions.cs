using System.Text;

namespace Carbon.Media
{
    internal static class StringBuilderExtensions
    {
        public static void Append(this StringBuilder sb, in Unit unit)
        {
            if (unit.Type == UnitType.Percentage)
            {
                sb.Append(unit.Value);
                sb.Append('%');
            }
            else if (unit.Type == UnitType.M)
            {
                sb.Append(unit.Value);
                sb.Append('m');
            }
            else if (unit.Type == UnitType.Ns)
            {
                sb.Append(unit.Value);
                sb.Append("ns");
            }
            else
            {
                sb.Append(unit.Value);
            }          
        }
    }
}