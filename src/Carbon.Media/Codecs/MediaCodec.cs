namespace Carbon.Media
{
	using System;

	using Carbon.Helpers;

	public struct MediaCodec
	{
		private readonly string name;
		private readonly MediaCodecType type;
		private readonly MediaCodecProfile profile;

		public MediaCodec(string name, MediaCodecType type, MediaCodecProfile profile = null)
		{
			#region Preconditions

			if (name == null)
				throw new ArgumentNullException("name");

			#endregion

			this.name = name;
			this.type = type;
			this.profile = profile;
		}

		public MediaCodecType Type
		{
			get { return type; }
		}

		public MediaCodecProfile Profile
		{
			get { return profile; }
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is MediaCodec)
			{
				var other = (MediaCodec)obj;

				return other.name == this.name;
			}

			return false;
		}

		public override string ToString()
		{
			return name;
		}

		public static MediaCodec Parse(string name)
		{
			#region Preconditions

			if (name == null)
				throw new ArgumentNullException("name");

			#endregion

			switch (name.ToUpper())
			{
				// H264 Profiles
				case "AVC1.42E01E": return H264Baseline;
				case "AVC1.4D401E": return H264Main;
				case "AVC1.58A01E": return H264Extended;	
				case "AVC1.64001E": return H264High;

				// AAC Profiles
				case "mp4a.40.2":	return AacLC;
			}

			var type = name.ToEnum<MediaCodecType>(ignoreCase: true);

			return new MediaCodec(type.ToString().ToLower(), type);
		}

		public static readonly MediaCodec AacLC			= new MediaCodec("mp4a.40.2", MediaCodecType.Aac);	// AAC-low complexity profile
		// public static readonly MediaCodecInfo AacHE	= new MediaCodecInfo("aac", CodecType.Aac);		// AAC-high efficiency profile

		public static readonly MediaCodec H264Baseline	= new MediaCodec("avc1.42E01E", MediaCodecType.H264, H264Profile.Baseline);
		public static readonly MediaCodec H264Main		= new MediaCodec("avc1.4D401E", MediaCodecType.H264, H264Profile.Main);
		public static readonly MediaCodec H264Extended	= new MediaCodec("avc1.58A01E", MediaCodecType.H264, H264Profile.Extended);
		public static readonly MediaCodec H264High		= new MediaCodec("avc1.64001E", MediaCodecType.H264, H264Profile.High);

		public static readonly MediaCodec Vorbis		= new MediaCodec("vorbis", MediaCodecType.Vorbis);

		public static readonly MediaCodec Vp8			= new MediaCodec("vp8", MediaCodecType.Vp8);

		// Images --------------------------------------------------------------------------------------------------
		public static readonly MediaCodec Bmp			= new MediaCodec("bmp", MediaCodecType.Bmp);
		public static readonly MediaCodec Gif			= new MediaCodec("gif", MediaCodecType.Gif);
		public static readonly MediaCodec Jpeg			= new MediaCodec("jpeg", MediaCodecType.Jpeg);
		public static readonly MediaCodec Jxr			= new MediaCodec("jxr", MediaCodecType.Jxr);
		public static readonly MediaCodec Png			= new MediaCodec("png", MediaCodecType.Png);
	}

	public abstract class MediaCodecProfile { }
}
