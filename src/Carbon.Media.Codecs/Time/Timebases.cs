namespace Carbon.Media
{
    public static class Timebases
    {
        public static readonly Rational Ffmpeg      = new Rational(1, 1_000_000);
        public static readonly Rational DotNetTicks = new Rational(1, 10_000_000);
    }
}