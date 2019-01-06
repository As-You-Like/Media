using System;

namespace Carbon.Media.Codecs
{
    public static class CodecIdHelper
    {
        public static CodecId Parse(string text)
        {
            // h264
            // aac

            if (Enum.TryParse(text, ignoreCase: true, out CodecId result))
            {
                return result;
            }

            throw new InvalidValueException(nameof(CodecId), text);
        }
    }
}