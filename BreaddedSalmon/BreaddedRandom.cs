using System;

namespace BS
{
	public class BreaddedRandom : Random
	{
		#region Singleton
		private static BreaddedRandom instance = null;
		private static readonly object padlock = new object ();

		public static BreaddedRandom Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new BreaddedRandom ();
					}
					return instance;
				}
			}
		}
		#endregion Singleton

		public bool Chance(float chance)
		{
			return NextDouble () < chance;
		}

		public float NextFloat(float max)
		{
			return NextFloat (0, max);
		}

		public float NextFloat(float min, float max)
		{
			return min + ((float) NextDouble () * (max - min));
		}
	}
}
