using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BS
{
	public class GameState
	{
		public string ID = "unknown";
		public StateManager Parent;

		public virtual void Update(GameTime gameTime)
		{
		}

		public virtual void Draw(SpriteBatch batch)
		{
		}

		public virtual void Enter(string from)
		{
		}

		public virtual void Leave(string to)
		{
		}

		public void SwitchState(string to)
		{
			Parent.SwitchState (to);
		}
	}
}
