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
    }
}
