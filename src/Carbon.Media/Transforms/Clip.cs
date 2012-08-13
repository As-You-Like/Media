namespace Carbon.Media
{
	using System;

	using Carbon.Helpers;

	public class Clip : ITransform
	{
		private readonly TimeSpan start;
		private readonly TimeSpan end;

		public Clip(TimeSpan start, TimeSpan end)
		{
			#region Preconditions

			if (end > start)
				throw new ArgumentException("end may not be after the start");

			#endregion

			this.start = start;
			this.end = end;
		}

		public TimeSpan Start 
		{
			get { return start; }
		}

		public TimeSpan End 
		{
			get { return end; }
		}

		public override string ToString() 
		{
			return string.Format("clip:{0}-{1}", start.TotalSeconds, end.TotalSeconds);
		}
	}
}