using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tainicom.Aether.Physics2D.Dynamics;

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
