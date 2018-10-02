namespace Carbon.Media
{
    public static class UnitTypeHelper
    {
        public static UnitType Parse(string text)
        {
            switch (text)
            {
                case "%"   : return UnitType.Percentage;
                case "px"  : return UnitType.Px;
                case "pt"  : return UnitType.Pt;
                case "m"   : return UnitType.M;
                case "cm"  : return UnitType.Cm;
                case "mm"  : return UnitType.Mm;
                case "s"   : return UnitType.S;
                case "ms"  : return UnitType.Ms;
                case "deg" : return UnitType.Deg;
                case "rad" : return UnitType.Rad;
                case "Hz"  : return UnitType.Hz;
                case "kHz" : return UnitType.Khz;
                case "x"   : return UnitType.X;
            }

            return UnitType.None;
        }

        public static string GetSymbol(UnitType type)
        {
            switch (type)
            {
                case UnitType.Percentage : return "%";  
                case UnitType.Px         : return "px";  
                case UnitType.Pt         : return "pt"; 
                case UnitType.M          : return "m"; 
                case UnitType.Cm         : return "cm";  
                case UnitType.Mm         : return "mm"; 
                case UnitType.S          : return "s"; 
                case UnitType.Ms         : return "ms";  
                case UnitType.Deg        : return "deg"; 
                case UnitType.Rad        : return "rad";
                case UnitType.Hz         : return "Hz";
                case UnitType.Khz        : return "kHz"; 
                case UnitType.X          : return "x";
            }

            return "";
        }
    }
}
