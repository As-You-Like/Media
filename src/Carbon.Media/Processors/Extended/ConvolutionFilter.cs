namespace Carbon.Media.Processors
{
    public class ConvolutionFilter
    {
        public float[] Matrix { get; set; }
    }

    // convolution="1 1 1 1 1 1 1 1 1:1 1 1 1 1 1 1 1 1:1 1 1 1 1 1 1 1 1:1 1 1 1 1 1 1 1 1:1/9:1/9:1/9:1/9"

    // 3x3 | 5x5, 7x7
}