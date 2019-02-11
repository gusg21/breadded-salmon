using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
	public class GameState
	{
		public BSGame Parent;

		protected GameObjectGroup objects = new GameObjectGroup();
		public FancyCamera camera;

		public virtual void LoadContent(ContentManager content)
		{
			objects.LoadContent (content);

			camera = new FancyCamera (Parent.GraphicsDevice);
		}

		public virtual void Update(GameTime gameTime)
		{
			objects.Update (gameTime);

			camera.Update (gameTime);
		}

		public virtual void Draw(SpriteBatch batch)
		{
			objects.Draw (batch);
		}
	}
}
