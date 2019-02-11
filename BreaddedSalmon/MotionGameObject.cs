using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BS
{
	public abstract class MotionGameObject : GameObject
	{
		public Vector2 position, velocity, acceleration = Vector2.Zero;

		public override void Update(GameTime gameTime)
		{
			velocity += acceleration;
			position += velocity;
		}
	}
}
