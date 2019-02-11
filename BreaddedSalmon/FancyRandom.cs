using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
	public class FancyRandom : Random
	{
		#region Singleton
		private static FancyRandom instance = null;
		private static readonly object padlock = new object ();

		public static FancyRandom Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
					{
						instance = new FancyRandom ();
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
