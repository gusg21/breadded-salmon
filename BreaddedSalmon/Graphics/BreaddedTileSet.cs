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
        public float speed { get; set; }

        private int TileWidth;
        private int TileHeight;
        private int TilesPer;

        private Vector2 center;

        public float Depth { get; set; }

        public BreaddedTileSet(Texture2D tex, int TileWidth, int TileHeight, int tilesPer, float Depth = 0)
        {
            this.tex = tex;
            this.TileWidth = TileWidth;
            this.TileHeight = TileHeight;
            this.Depth = Depth;
            this.center = Vector2.Zero;

        }
        public void Center()
        {

        }
        public void Update(GameTime gameTime)
        {

        }

		public Rectangle GetTileRectangle(int index)
		{
			return new Rectangle (index % TilesPer * TileWidth, (int) Math.Ceiling ((double) (index / TilesPer)), TileWidth, TileHeight);
		}

        public void Draw(SpriteBatch batch, int x, int y, int index)
        {
            batch.Draw(tex, new Vector2(x, y), GetTileRectangle(index), Color.White, 0, center, 0, SpriteEffects.None, Depth);
        }
    }
}
