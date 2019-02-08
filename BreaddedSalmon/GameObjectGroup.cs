using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BS
{
	public class GameObjectGroup : GameObject
	{
		public List<GameObject> children = new List<GameObject> ();

		public override void Update(GameTime gameTime)
		{
			foreach (GameObject @object in children)
			{
				if (@object.alive)
					@object.Update (gameTime);

				if (!@object.exists)
					children.Remove (@object);
			}
		}

		public override void Draw(SpriteBatch batch)
		{
			foreach (GameObject @object in children)
			{
				@object.Draw (batch);
			}
		}
	}
}
