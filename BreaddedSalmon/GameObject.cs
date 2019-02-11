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
	public class GameObject
	{
		public bool alive = true;
		public bool exists = true;

		public float depth = 0F;


		public virtual void LoadContent(ContentManager content)
		{
			Console.WriteLine ("Load Content Base");
		}
		public virtual void Update(GameTime gameTime) { }
		public virtual void Draw(SpriteBatch batch) { }
	}
}
