using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Carbon.Media.Metadata.Tests
{
    public class ModelTests
    {
        [Fact]
        public void A()
        {
            Assert.Equal("EOS5",           Model.Parse("Canon EOS5").Name);
            Assert.Equal("PowerShot A460", Model.Parse("Canon PowerShot A460").Name);

        }
    }


    public class SoftwareTests
    {
        [Fact]
        public void A()
        {
            SoftwareInfo.TryParse("Adobe Photoshop CS3 Windows", out SoftwareInfo software);

            Assert.Equal("Adobe Photoshop", software.Name);
            Assert.Equal("CS3",             software.Version);
            Assert.Equal("Windows",         software.Platform);

        }

        [Fact]
        public void B()
        {
            SoftwareInfo.TryParse("Adobe Photoshop CS7", out SoftwareInfo software);

            Assert.Equal("Adobe Photoshop", software.Name);
            Assert.Equal("CS7", software.Version);
            Assert.Null(software.Platform);
        }

        [Fact]
        public void C()
        {
            SoftwareInfo.TryParse("Adobe Illustrator", out SoftwareInfo software);

            Assert.Equal("Adobe Illustrator", software.Name);
            Assert.Null(software.Version);
            Assert.Null(software.Platform);
        }
    }
}
