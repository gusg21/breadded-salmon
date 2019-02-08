using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
	static class GenerateTexture
	{
		public static Texture2D Rectangle(GraphicsDevice graphicsDevice, Rectangle rect, Color color)
		{
			return Rectangle (graphicsDevice, rect.Width, rect.Height, color);
		}

		public static Texture2D Rectangle(GraphicsDevice graphicsDevice, int w, int h, Color color)
		{
			byte [] colors = new byte [w * h * 4];

			for (int i = 0; i < w * h; i++)
			{
				colors [i * 4] = color.R;
				colors [i * 4 + 1] = color.G;
				colors [i * 4 + 2] = color.B;
				colors [i * 4 + 3] = color.A;
			}

			Texture2D ret = new Texture2D (graphicsDevice, w, h);
			ret.SetData (colors);

			return ret;
		}

		static double Distance(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt (Math.Pow (x2 - x1, 2) + Math.Pow (y2 - y1, 2));
		}

		public static Texture2D Circle(GraphicsDevice graphicsDevice, Color color, int radius, int? width = null, int? height = null)
		{
			if (width == null)
				width = radius * 2;
			if (height == null)
				height = radius * 2;

			byte [] colors = new byte [(int) width * (int) height * 4];

			for (int i = 0; i < (int) width * (int) height; i++)
			{
				int x = i % (int)width;
				int y = (int) i / (int)height;
				if (Distance(x, y, radius, radius) < radius)
				{
					colors [i * 4] = color.R;
					colors [i * 4 + 1] = color.G;
					colors [i * 4 + 2] = color.B;
					colors [i * 4 + 3] = color.A;
				}
				else
				{
					colors [i * 4] = 0x00;
					colors [i * 4 + 1] = 0x00;
					colors [i * 4 + 2] = 0x00;
					colors [i * 4 + 3] = 0x00;
				}
			}

			Texture2D ret = new Texture2D (graphicsDevice, (int) width, (int) height);
			ret.SetData (colors);

			return ret;
		}
	}
}
