namespace Carbon.Media
{
    public class QualityHelper
    {
        public static int Parse(string text)
        {
            switch (text)
            {
                case "lossless": return 100;
            }

            return int.Parse(text);
        }
    }
}
