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
        public void Guess()
        {   
            Assert.Equal(Mime.Aac,  Check("fff1508001a00027000320641cfff150")); // aac
            Assert.Equal(Mime.Aac,  Check("fff150804b6000274eff315f8ec00000")); // aac
            Assert.Equal(Mime.Aiff, Check("464f524d003bca584149464346564552")); // aiff
            Assert.Equal(Mime.Aiff, Check("464f524d0050c9084149464346564552")); // aiff
            Assert.Equal(Mime.Aiff, Check("464f524d0000319641494646434f4d4d")); // aiff
            Assert.Equal(Mime.Asf,  Check("3026b2758e66cf11a6d900aa0062ce6c")); // asf
            Assert.Equal(Mime.Avi,  Check("5249464600975700415649204c495354")); // avi
            Assert.Equal(Mime.Avi,  Check("524946460e221304415649204c495354")); // avi
            Assert.Equal(Mime.Bmp,  Check("424dbe654a0100000000360000002800")); // bmp
            Assert.Equal(Mime.Bmp,  Check("424d2c4f8101000000001a0000000c00")); // bmp
            Assert.Equal(Mime.Bmp,  Check("424d9a84230000000000360000002800")); // bmp
            Assert.Equal(Mime.Flac, Check("664c6143000000220480048000000e00")); // flac | @0 -> fLaC
            Assert.Equal(Mime.Flac, Check("664c6143000000221000100000093600")); // flac | @0 -> fLaC
            Assert.Equal(Mime.Flac, Check("664c6143000000220480048000000e00")); // flac | @0 -> fLaC
            Assert.Equal(Mime.Flv,  Check("464c5601050000000900000000120000")); // flv
            Assert.Equal(Mime.Flv,  Check("464c5601010000000900000000120000")); // flv
            Assert.Equal(Mime.Gif,  Check("4749463839615203"));                 // GIF89a
            Assert.Equal(Mime.Gif,  Check("4749463839619001"));                 // GIF89a
            Assert.Equal(Mime.Gif,  Check("4749463839615203"));                 // GIF89a
            Assert.Equal(Mime.Gif,  Check("4749463839618002"));                 // GIF89as
            Assert.Equal(Mime.Ico,  Check("000001000200101000000000200068")); // ico
            Assert.Equal(Mime.Ico,  Check("000001000100101010000100040028")); // ico
            Assert.Equal(Mime.Jpeg, Check("ffd8ffe000104a4649460001010100")); // jpeg
            Assert.Equal(Mime.Mpeg, Check("000001ba44000400040100f77bf800")); // mpeg
            Assert.Equal(Mime.Mpeg, Check("000001ba2100010011800e6f000001")); // mpeg
            Assert.Equal(Mime.Mpeg, Check("000001ba2100031941801b91000001")); // mpeg
            Assert.Equal(Mime.Mpeg, Check("000001ba4400040004010148ebf800")); // mpeg
            Assert.Equal(Mime.M4v,  Check("00000020667479704d345648000000")); // m4v | @4 -> ftypM4VH
            Assert.Equal(Mime.M4v,  Check("0000001c667479704d345620000000")); // m4v | @4 -> ftypM4V
            Assert.Equal(Mime.Mp3,  Check("fffbb464000ff00000690000000800")); // mp3 | no ID3
            Assert.Equal(Mime.Mp3,  Check("4944330200000000103b434f4d0000")); // mp3 | ID3)
            Assert.Equal(Mime.Mp3,  Check("4944330300000000001654454e4300")); // mp3
            Assert.Equal(Mime.M4a,  Check("00000020667479704d344120000000")); // m4a
            Assert.Equal(Mime.Mov,  Check("000000206674797071742020200503")); // mov | @4 -> ftypM4VH
            Assert.Equal(Mime.Mov,  Check("000000146674797071742020000000")); // mov | @4 -> ftypqt
            Assert.Equal(Mime.Mp4,  Check("00000018667479706d703432000000")); // mp4
            Assert.Equal(Mime.Mp4,  Check("000000186674797069736f6d000000")); // mp4
            Assert.Equal(Mime.Mp4,  Check("0000001c667479704d534e56012900")); // mp4
            Assert.Equal(Mime.Mp4,  Check("00000018667479706d703432011e00")); // mp4
            Assert.Equal(Mime.Mp4,  Check("00000018667479706d703432000000")); // mp4
            Assert.Equal(Mime.Mp4,  Check("0000001c667479706d703432000000")); // mp4
            Assert.Equal(Mime.Mp4,  Check("000000206674797069736f6d000002")); // mp4
            Assert.Equal(Mime.Mp4,  Check("000000146674797069736f6d000002")); // mp4
            Assert.Equal(Mime.Mp4,  Check("0000001c6674797069736f6d000002")); // mp4
            Assert.Equal(Mime.Mp4,  Check("00000020667479706d703432000000")); // mp4
            Assert.Equal(Mime.Mp4,  Check("0000001c6674797046414345000005")); // mp4 | @4 -> ftypFACE
            Assert.Equal(Mime.Ogv,  Check("4f676753000200000000000000004a")); // ogv
            Assert.Equal(Mime.Pdf,  Check("255044462d312e340a25f6e4fcdf0a")); // pdf
            Assert.Equal(Mime.Pdf,  Check("255044462d312e360d25e2e3cfd30d")); // pdf
            Assert.Equal(Mime.Pdf,  Check("255044462d312e330a25e2e3cfd30a")); // pdf
            Assert.Equal(Mime.Pdf,  Check("255044462d312e350d25e2e3cfd30d")); // pdf (was ai)
            Assert.Equal(Mime.Pdf,  Check("255044462d312e350d25e2e3cfd30d")); // pdf (was ai)
            Assert.Equal(Mime.Png,  Check("89504e470d0a1a0a0000000d494844")); // png
            Assert.Equal(Mime.Png,  Check("89504e470d0a1a0a0000000d494844")); // png
            Assert.Equal(Mime.Psd,  Check("384250530001000000000000000300")); // psd
            Assert.Equal(Mime.Tiff, Check("49492a00080000001500fe00040001")); // tiff
            Assert.Equal(Mime.Tiff, Check("49492a000800c0009b9b9b9b9b9b9b")); // tiff
            Assert.Equal(Mime.Tiff, Check("4d4d002a022d04ecffffffffffffff")); // tiff
            Assert.Equal(Mime.Tiff, Check("49492a00080000001400fe00040001")); // tiff
            Assert.Equal(Mime.Wav,  Check("5249464624804f0057415645666d74")); // wav
            Assert.Equal(Mime.Wav,  Check("52494646d4b6550157415645666d74")); // wav
            Assert.Equal(Mime.WebM, Check("1a45dfa3010000000000001f428681")); // webm


            //  Assert.Equal(Mime.Mov, Check("0000000877696465004831d26d6461")); // mov | wide h1 mda

        }
        
        // [Fact]
        public string GetBytes()
        {
            throw new Exception(string.Join(", ", Encoding.ASCII.GetBytes("ftypmp41").Select(b => "0x" + b.ToString("x2"))));
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
