namespace Carbon.Media.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class VideoHelperTests
	{
		[Test]
		public void ParseCodec()
		{
			Assert.AreEqual(MediaCodecType.H264,		MediaCodec.Parse("avc1.4D401E").Type);
			Assert.AreEqual(MediaCodecType.Vp6,		MediaCodec.Parse("vp6").Type);
			Assert.AreEqual(MediaCodecType.Vp8,		MediaCodec.Parse("vp8").Type);
			Assert.AreEqual(MediaCodecType.Theora,	MediaCodec.Parse("theora").Type);
		}

		[Test]
		public void ParseProfile()
		{
			Assert.AreEqual(H264ProfileType.Baseline,	((H264Profile)MediaCodec.Parse("avc1.42E01E").Profile).Type);
			Assert.AreEqual(H264ProfileType.Extended,	((H264Profile)MediaCodec.Parse("avc1.58A01E").Profile).Type);
			Assert.AreEqual(H264ProfileType.Main,		((H264Profile)MediaCodec.Parse("avc1.4D401E").Profile).Type);
			Assert.AreEqual(H264ProfileType.High,		((H264Profile)MediaCodec.Parse("avc1.64001E").Profile).Type);

			Assert.AreEqual(MediaCodec.H264High, MediaCodec.Parse("avc1.64001E"));
			Assert.AreEqual("avc1.64001E", MediaCodec.H264High.ToString());
		}
	}
}

/*
H.264 Constrained baseline profile video (main and extended video compatible) level 3 and Low-Complexity AAC audio in MP4 container
<source src='video.mp4' type='video/mp4; codecs="avc1.42E01E, mp4a.40.2"'>

H.264 Extended profile video (baseline-compatible) level 3 and Low-Complexity AAC audio in MP4 container
<source src='video.mp4' type='video/mp4; codecs="avc1.58A01E, mp4a.40.2"'>

H.264 Main profile video level 3 and Low-Complexity AAC audio in MP4 container
<source src='video.mp4' type='video/mp4; codecs="avc1.4D401E, mp4a.40.2"'>

H.264 'High' profile video (incompatible with main, baseline, or extended profiles) level 3 and Low-Complexity AAC audio in MP4 container
<source src='video.mp4' type='video/mp4; codecs="avc1.64001E, mp4a.40.2"'>

MPEG-4 Visual Simple Profile Level 0 video and Low-Complexity AAC audio in MP4 container
<source src='video.mp4' type='video/mp4; codecs="mp4v.20.8, mp4a.40.2"'>

MPEG-4 Advanced Simple Profile Level 0 video and Low-Complexity AAC audio in MP4 container

    <source src='video.mp4' type='video/mp4; codecs="mp4v.20.240, mp4a.40.2"'>

MPEG-4 Visual Simple Profile Level 0 video and AMR audio in 3GPP container

    <source src='video.3gp' type='video/3gpp; codecs="mp4v.20.8, samr"'>

Theora video and Vorbis audio in Ogg container

    <source src='video.ogv' type='video/ogg; codecs="theora, vorbis"'>

Theora video and Speex audio in Ogg container

    <source src='video.ogv' type='video/ogg; codecs="theora, speex"'>

Vorbis audio alone in Ogg container

    <source src='audio.ogg' type='audio/ogg; codecs=vorbis'>

Speex audio alone in Ogg container

    <source src='audio.spx' type='audio/ogg; codecs=speex'>

FLAC audio alone in Ogg container

    <source src='audio.oga' type='audio/ogg; codecs=flac'>

Dirac video and Vorbis audio in Ogg container

    <source src='video.ogv' type='video/ogg; codecs="dirac, vorbis"'>

Theora video and Vorbis audio in Matroska container

    <source src='video.mkv' type='video/x-matroska; codecs="theora, vorbis"'>
*/