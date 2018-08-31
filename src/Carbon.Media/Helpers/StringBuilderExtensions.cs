using System.Text;

namespace Carbon.Media
{
    internal static class StringBuilderExtensions
    {
        public static void Append(this StringBuilder sb, in Unit unit)
        {
            if (unit.Type == UnitType.Percent)
            {
                sb.Append(unit.Value * 100);
                sb.Append('%');
            }
            else if (unit.Type == UnitType.Meter)
            {
                sb.Append(unit.Value);
                sb.Append('m');
            }
            else
            {
                sb.Append(unit.Value);
            }          
        }
    }
}