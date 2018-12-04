using System;

namespace Carbon.Media
{
    public static class FrameRates
    {
        public static readonly Rational  _24Hz = new Rational(24, 1);
        public static readonly Rational  _25Hz = new Rational(25, 1);
        public static readonly Rational  _30Hz = new Rational(30, 1);
        public static readonly Rational  _50Hz = new Rational(50, 1);
        public static readonly Rational  _60Hz = new Rational(60, 1);
        public static readonly Rational _100Hz = new Rational(100, 1);
        public static readonly Rational _120Hz = new Rational(120, 1);
        public static readonly Rational _240Hz = new Rational(240, 1);

        // NTSC Compability
        public static readonly Rational _23_97Hz  = new Rational(24000, 1001);  // 23.976fps
        public static readonly Rational _29_97Hz  = new Rational(30000, 1001);  // 29.97fps       | 30DF
        public static readonly Rational _59_94Hz  = new Rational(60000, 1001);  // 59.94fps
        public static readonly Rational _119_88Hz = new Rational(120000, 1001); // 119.88fps

        public static readonly Rational Atsc     = _30Hz;
        public static readonly Rational Film     = _24Hz;
        public static readonly Rational Pal      = _25Hz;    // 25/1
        public static readonly Rational Ntsc     = _29_97Hz; // 30000/1001
        public static readonly Rational NtscFilm = _23_97Hz; // 24000/1001

        public static Rational Parse(string text)
        {
            if (text.IndexOf('/') > 0)
            {
                return Rational.Parse(text);
            }
            
            // Aliases
            switch (text)
            {
                case "23.97"     : return _23_97Hz;
                case "29.97"     : return _29_97Hz;
                case "59.94"     : return _59_94Hz;
                case "119.88"    : return _119_88Hz;
                case "atsc"      : return Atsc;
                case "film"      : return Film;
                case "qpal"      : return Pal;
                case "pal"       : return Pal;
                case "ntsc"      : return Ntsc;
                case "ntsc-film" : return NtscFilm;
            }

            // e.g. 30fps
            if (text.EndsWith("fps") && int.TryParse(text.Substring(0, text.Length - 3), out int fps))
            {
                return new Rational(fps, 1);
            }
            // e.g. 30
            else if (int.TryParse(text.Substring(0, text.Length - 3), out fps))
            {
                return new Rational(fps, 1);
            }

            throw new Exception("unknown frame rate:" + text);
        }

    }


   
}



// 24, 25 (24.98), 30 (29.97), 60

// The ATSC standard allows frame rates of 23.976, 24, 29.97, 30, 59.94, and 60 frames per second.

// A frequency offset of 0.03Hz was introduced to make space in time for the color sub-carrier.

// X/1001 rates are considred 'drop down' (from their integer).
// pull down referrered to the cadence of frames when fitting 24 or 25 frames into a 30fps program

// SMPTE