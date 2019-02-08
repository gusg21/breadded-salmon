using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
	public abstract class GameObject
	{
		public bool alive = true;
		public bool exists = true;

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(SpriteBatch batch);
	}
}
