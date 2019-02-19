using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Graphics
{
    public class BreaddedAnimation
    {
		BreaddedTileSet tileset;
		Range<int> frames;
		float currentFrame;
		float framesPerSecond;

		public BreaddedAnimation(BreaddedTileSet tileset, Range<int> frames, float framesPerSecond)
        {
			this.tileset = tileset;
			this.frames = frames;

			currentFrame = 0;
			this.framesPerSecond = framesPerSecond;
        }

		public void Reset()
		{
			currentFrame = 0;
		}

		public void Update(GameTime gameTime)
		{
			currentFrame += framesPerSecond;
			currentFrame = currentFrame % (frames.Max - frames.Min);
		}

		public void Draw(SpriteBatch batch, int x, int y)
		{
			tileset.Draw (batch, x, y, (int) Math.Floor(currentFrame + frames.Min));
		}
    }
}
