namespace Carbon.Media
{
    public struct BitRate
    {
        public long value;

        public BitRate(long value)
        {
            this.value = value;
        }

        public long Value => value;
    }
}
