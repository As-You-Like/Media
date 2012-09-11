namespace Carbon.Media
{
	using System;

	using Carbon.Helpers;

	public class ApplyFilter : ITransform
	{
		private readonly string name;
		private readonly string value;

		public ApplyFilter(string name, string value)
		{
			this.name = name;
			this.value = value;
		}

		public string Name 
		{
			get { return name; }
		}

		public string Value
		{
			get { return value; }
		}

		public override string ToString()
		{
			return string.Format("{0}({1})", name, value);
		}

		public static ApplyFilter Parse(string key)
		{
			var name = key.Split('(')[0];
			var value = key.Split('(')[1].TrimEnd(')');

			return new ApplyFilter(name, value);
		}
	}
}