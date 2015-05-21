﻿namespace Carbon.Media
{
	public struct Point
	{
		private readonly int x;
		private readonly int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public int X => x;

		public int Y => y;
	}
}
