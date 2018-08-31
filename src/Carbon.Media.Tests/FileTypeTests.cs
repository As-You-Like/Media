using System;
using System.Text;

using Carbon.Extensions;

using Xunit;

namespace Carbon.Media.Tests
{
    public class FileTypeTests
    {
        [Fact]
        public void Guess()
        {   
            Assert.Equal(Mime.Aac,  Check("fff1508001a00027000320641cfff150")); // aac
            Assert.Equal(Mime.Aiff, Check("464f524d003bca584149464346564552")); // aiff
            Assert.Equal(Mime.Asf,  Check("3026b2758e66cf11a6d900aa0062ce6c")); // asf
            Assert.Equal(Mime.Avi,  Check("5249464600975700415649204c495354")); // avi
            Assert.Equal(Mime.Bmp,  Check("424dbe654a0100000000360000002800")); // bmp
            Assert.Equal(Mime.Bmp,  Check("424d2c4f8101000000001a0000000c00")); // bmp
            Assert.Equal(Mime.Flac, Check("664c6143000000220480048000000e00")); // flac
            Assert.Equal(Mime.Flac, Check("664c6143000000221000100000093600")); // flac
            Assert.Equal(Mime.Flac, Check("664c6143000000220480048000000e00")); // flac
            Assert.Equal(Mime.Flv,  Check("464c5601050000000900000000120000")); // flv
            Assert.Equal(Mime.Gif,  Check("4749463839615203"));                 // GIF89a
            Assert.Equal(Mime.Gif,  Check("4749463839619001"));                 // GIF89a
            Assert.Equal(Mime.Gif,  Check("4749463839615203"));                 // GIF89a
            Assert.Equal(Mime.Gif,  Check("4749463839618002"));                 // GIF89as
            Assert.Equal(Mime.Ico,  Check("00000100020010100000000020006804")); // ico
            Assert.Equal(Mime.Ico,  Check("00000100010010101000010004002801")); // ico
            Assert.Equal(Mime.Jpeg, Check("ffd8ffe000104a464946000101010048")); // jpeg
            Assert.Equal(Mime.Mpeg, Check("000001ba44000400040100f77bf80000")); // mpeg
            Assert.Equal(Mime.Mp3,  Check("fffbb464000ff0000069000000080000")); // mp3 (no ID3)
            Assert.Equal(Mime.Mp3,  Check("4944330200000000103b434f4d000010")); // mp3 (ID3)
            Assert.Equal(Mime.Pdf,  Check("255044462d312e340a25f6e4fcdf0a31")); // pdf
            Assert.Equal(Mime.Pdf,  Check("255044462d312e360d25e2e3cfd30d0a")); // pdf
            Assert.Equal(Mime.Pdf,  Check("255044462d312e330a25e2e3cfd30a32")); // pdf
            Assert.Equal(Mime.Pdf,  Check("255044462d312e350d25e2e3cfd30d0a")); // pdf (was ai)
            Assert.Equal(Mime.Pdf,  Check("255044462d312e350d25e2e3cfd30d0a")); // pdf (was ai)
            Assert.Equal(Mime.Png,  Check("89504e470d0a1a0a0000000d49484452")); // png
            Assert.Equal(Mime.Png,  Check("89504e470d0a1a0a0000000d49484452")); // png
            Assert.Equal(Mime.Psd,  Check("38425053000100000000000000030000")); // psd
            Assert.Equal(Mime.Tiff, Check("49492a00080000001500fe0004000100")); // tiff
            Assert.Equal(Mime.Tiff, Check("49492a000800c0009b9b9b9b9b9b9b9b")); // tiff
            Assert.Equal(Mime.Tiff, Check("4d4d002a022d04ecffffffffffffffff")); // tiff
            Assert.Equal(Mime.Tiff, Check("49492a00080000001400fe0004000100")); // tiff
            Assert.Equal(Mime.WebM, Check("1a45dfa3010000000000001f42868101")); // webm


            Assert.Equal(Mime.Mov, Check("00000018667479706d703432000000006d70"));

            // Assert.Equal(Mime.Jpeg, Check("fd8ffe000104a46494600010100000100010"));

            // MOV
            Assert.Equal(Mime.Mov, Check("000000206674797071")); // ftyp @ 4

            // mp4
            Assert.Equal(Mime.Mov, Check("000000186674797069736f6d0000000169736f6d6176633100023edc6d6f6f760000006c6d766864000000"));

            // m4v
            Assert.Equal(Mime.Mov, Check("00000020667479704d345648000000014d3456484d3441206d70343269736f6d0000e68f6d6f6f76000000"));

            // mpeg
            Assert.Equal(Mime.Mpeg, Check("000001ba44000400040100f77bf8000001bb000c807bbd04217fe0e0e0c0c020000001be07daff"));
        }

        public Mime Check(string hexString)
        {
            var data = HexString.ToBytes(hexString);

            var mime = FormatDetector.Detect(data);

            if (mime is null)
            {
                Throw(data);
            }

            return mime;
        }

        private void Throw(byte[] data)
        {
            throw new Exception(string.Join(Environment.NewLine, new[] {
                HexString.FromBytes(data),
                Encoding.ASCII.GetString(data)
            }));
        }
    }
}
