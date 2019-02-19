using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Graphics
{
    public class BreaddedTileSet
    {
        private Texture2D tex;
        public float Speed { get; set; }

        private int tileWidth;
        private int tileHeight;
        private int tilesPerRow;

        private Vector2 center;

        public float Depth { get; set; }

        public BreaddedTileSet(Texture2D tex, int tileWidth, int tileHeight, int tilesPerRow, float Depth = 0)
        {
            this.tex = tex;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.Depth = Depth;
            this.center = Vector2.Zero;
			this.tilesPerRow = tilesPerRow;
        }
        public void Center()
        {

        }
        public void Update(GameTime gameTime)
        {

        }

		public Rectangle GetTileRectangle(int index)
		{
			return new Rectangle (index % tilesPerRow * tileWidth, (int) Math.Ceiling ((double) (index / tilesPerRow)), tileWidth, tileHeight);
		}

        public void Draw(SpriteBatch batch, int x, int y, int index)
        {
            batch.Draw(tex, new Vector2(x, y), GetTileRectangle(index), Color.White);
        }
    }
}
