namespace Carbon.Media.Codecs.Resampling
{
    public class ResamplerParameters
    {
        public ResamplerParameters(AudioFormatInfo input, AudioFormatInfo output)
        {
            Input = input;
            Output = output;
        }

        public AudioFormatInfo Input { get; }

        public AudioFormatInfo Output { get; }
    }
}