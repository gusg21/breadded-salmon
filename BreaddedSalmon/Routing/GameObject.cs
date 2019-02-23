using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BS
{
	public class GameObject
	{
		public bool alive = true;
		public bool exists = true;

		public float depth = 0F;


		public virtual void LoadContent(ContentManager content) { }
		public virtual void Update(GameTime gameTime) { }
		public virtual void Draw(SpriteBatch batch) { }
	}
}
