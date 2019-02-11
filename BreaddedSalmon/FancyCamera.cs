using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
	public class FancyCamera : Camera
	{
		public Vector2 Target = Vector2.Zero;
		public float smoothing = 0.08F;
		public bool useTargeting = true;

		public bool Shaking {
			get
			{
				return currentShake.timeLeft > 0;
			}
		}
		ShakeConfig currentShake;

		Vector2 InternalPosition;
		Vector2 Offset;
		public new Vector2 Position
		{
			get
			{
				return InternalPosition + Offset;
			}
			set
			{
				InternalPosition = value;
			}
		}

		public FancyCamera(GraphicsDevice device) : base (device) { }

		public new void Update(GameTime gameTime)
		{
			if (useTargeting)
			{
				InternalPosition = Vector2.Lerp (InternalPosition, Target, smoothing);
			}

			if (Shaking)
			{
				Console.WriteLine (FancyRandom.Instance.NextFloat (-currentShake.intensity, currentShake.intensity));
				Offset = new Vector2 (
					FancyRandom.Instance.NextFloat (-currentShake.intensity, currentShake.intensity),
					FancyRandom.Instance.NextFloat (-currentShake.intensity, currentShake.intensity)
					);
			}
			else
			{
				Offset = Vector2.Zero;
			}
			currentShake.timeLeft -= (float) gameTime.ElapsedGameTime.TotalSeconds;

			base.Update (gameTime);
		}

		public void Shake(ShakeConfig shake)
		{
			currentShake = shake;
		}
	}

	public struct ShakeConfig
	{
		public float timeLeft;
		public float intensity;

		public ShakeConfig(float length, float intensity)
		{
			timeLeft = length;
			this.intensity = intensity;
		}

		public static ShakeConfig Impact = new ShakeConfig (0.3F, 3F);
		public static ShakeConfig Rumble = new ShakeConfig (1.4F, 1F);
	}
}
