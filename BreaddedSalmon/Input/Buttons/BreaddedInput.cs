using Microsoft.Xna.Framework;

namespace BS.Input
{
	public abstract class BreaddedInput
	{
		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual bool Pressed()
        {
            return false;

        }
        public virtual bool Released()
        {
            return false;

        }
        public virtual bool Check()
        {
            return false;
        }

	}
}
