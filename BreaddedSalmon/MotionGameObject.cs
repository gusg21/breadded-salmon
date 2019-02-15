using Microsoft.Xna.Framework;

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
