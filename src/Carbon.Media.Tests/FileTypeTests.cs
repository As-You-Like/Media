using System;
using System.Linq;
using System.Text;

using Carbon.Extensions;

using Xunit;

namespace Carbon.Media.Tests
{
    public class FileTypeTests
    {
        [Fact]
        public void PngTests()
        {
            Assert.True(MagicNumber.Png.Matches(new byte[] { 46, 80, 78, 71 }));        // 47 | 137 starting
            Assert.True(MagicNumber.Png.Matches(new byte[] { 137, 80, 78, 71 }));
        }

        [Fact]
        public void Guess()
        {
            // ICO
            Assert.Equal(Mime.Ico,  Check("00000100020010100000000020006804"));
            Assert.Equal(Mime.Ico,  Check("00000100010010101000010004002801"));

            // PDF
            Assert.Equal(Mime.Pdf,  Check("255044462d312e340a25f6e4fcdf0a31"));
            Assert.Equal(Mime.Pdf,  Check("255044462d312e360d25e2e3cfd30d0a"));
            Assert.Equal(Mime.Pdf,  Check("255044462d312e330a25e2e3cfd30a32"));

            // TIFF
            Assert.Equal(Mime.Tiff, Check("49492a00080000001500fe0004000100"));
            Assert.Equal(Mime.Tiff, Check("49492a000800c0009b9b9b9b9b9b9b9b"));
            Assert.Equal(Mime.Tiff, Check("4d4d002a022d04ecffffffffffffffff"));

            // PNG
            Assert.Equal(Mime.Png,  Check("89504e470d0a1a0a0000000d49484452"));
            Assert.Equal(Mime.Png,  Check("89504e470d0a1a0a0000000d49484452"));
            
            // Assert.Equal(Mime.Jpeg, Check("fd8ffe000104a46494600010100000100010"));
            Assert.Equal(Mime.Jpeg, Check("ffd8ffe000104a4649460001010100480048"));
            
            // PSD
            Assert.Equal(Mime.Psd,  Check("3842505300010000000000000003000003"));
            Assert.Equal(Mime.Psd,  Check("3842505300010000000000000003000008"));
            
            // FLAC
            Assert.Equal(Mime.Flac, Check("664c6143000000220480048000000e0010"));
            Assert.Equal(Mime.Flac, Check("664c61430000002210001000000936004f"));
        }

        
        public Mime Check(string hexString)
        {
            var data = HexString.ToBytes(hexString);

            var mime = FormatDetector.Detect(data);

            if (mime == null)
            {
                throw new Exception(string.Join(Environment.NewLine, new[] {
                    string.Join(",", data.Take(20).ToArray()),
                    Encoding.ASCII.GetString(data),
                    hexString
                }));
            }

            return mime;
        }
    }
}
