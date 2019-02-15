using Microsoft.Xna.Framework;

namespace BS.Input
{
	public abstract class BreaddedInput
	{
		public virtual void Update(GameTime gameTime)
		{

		}

		public abstract bool Pressed();
		public abstract bool Released();
		public abstract bool Check();
	}
}
