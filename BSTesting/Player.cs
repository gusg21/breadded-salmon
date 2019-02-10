using BS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTesting
{
	class Player : MotionGameObject
	{
		Texture2D sprite;

		public Player()
		{
			velocity.X = 2;

			sprite = Global.content.Load<Texture2D> ("Images/player.png");
		}

		public override void Update(GameTime gameTime)
		{
			base.Update (gameTime);
		}

		public override void Draw(SpriteBatch batch)
		{
			Debug.WriteLine ("Draw");

			batch.Draw (sprite, position, Color.White);
		}
	}
}
