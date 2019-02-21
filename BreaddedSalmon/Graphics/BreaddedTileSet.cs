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

        private int numberOfTiles;


        private Vector2 center;

        public float Depth { get; set; }

        public BreaddedTileSet(Texture2D tex, int tileWidth, int tileHeight, int tilesPerRow = 0, float Depth = 0)
        {
            this.tex = tex;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.Depth = Depth;
            this.center = Vector2.Zero;
            if (tilesPerRow < 1)
            {
                this.tilesPerRow = (int)(tex.Width / tileWidth);
            }
            this.numberOfTiles = ((int)((tex.Width / tileWidth) % tilesPerRow) * (int)(tex.Height / tileHeight));
        }
        public void Center()
        {

        }
        public void Update(GameTime gameTime)
        {

        }

        public Rectangle GetTileRectangle(int index)
        {
            return new Rectangle(index % tilesPerRow * tileWidth, (int)Math.Ceiling((double)(index / tilesPerRow)), tileWidth, tileHeight);
        }

        public void Draw(SpriteBatch batch, int x, int y, int index)
        {
            batch.Draw(tex, new Vector2(x, y), GetTileRectangle(index), Color.White);
        }
        public Texture2D getTile(int index)
        {
            return GenerateTexture.Crop(tex, (index % tilesPerRow) * tileWidth, (int)(index / tilesPerRow), (index % tilesPerRow) * tileWidth + tileWidth, (int)(index / tilesPerRow) + tileHeight);
        }
        public List<Texture2D> getTiles()
        {
            List<Texture2D> toOut = new List<Texture2D>();
            for (int i = 0; i < numberOfTiles; i++)
            {
                Texture2D tmp = getTile(i);

                Texture2D empty = GenerateTexture.Rectangle(tmp.GraphicsDevice, new Rectangle(0, 0, tmp.Width, tmp.Height), Color.Transparent);
                if (tmp != empty)
                {
                    toOut.Add(getTile(i));
                }
                }
            return toOut;
        }

    }
}
