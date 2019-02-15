using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BS
{
	public static class GenerateTexture
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
				int x = i % (int) width;
				int y = (int) i / (int) height;
				if (Distance (x, y, radius, radius) < radius)
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

		public static byte [] Convert2DArrayTo1D(byte [,] array)
		{
			int width = array.GetLength (0);
			int height = array.GetLength (1);
			byte [] output = new byte [width * height];
			int i = 0;
			for (int row = 0; row < height; row++)
			{
				for (int x = 0; x < width; x++)
				{
					output [i] = array [x, row];
					i++;
				}

			}
			return output;

		}

		private static Color [,] ArrayRectangle(int width, int height, Color color)
		{
			Color [,] output = new Color [width, height];
			for (int row = 0; row < height; row++)
			{
				for (int x = 0; x < width; x++)
				{
					output [x, row] = color;
				}
			}
			return output;
		}

		private static byte [,] ColorArrayToByte(Color [,] array)
		{
			int width = array.GetLength (0);
			int height = array.GetLength (1);

			byte [,] output = new byte [width * 4, height];

			int i = 0;
			for (int row = 0; row < height; row++)
			{
				for (int x = 0; x < width; x++)
				{
					output [x * 4, row] = array [x, row].R;
					output [x * 4 + 1, row] = array [x, row].G;
					output [x * 4 + 2, row] = array [x, row].B;
					output [x * 4 + 3, row] = array [x, row].A;
				}
			}

			return output;
		}

		public static Texture2D RoundedRectangle(GraphicsDevice graphicsDevice, Color color, int width, int height, double radius)
		{
			Color [,] colors = new Color [width, height];

			for (int y = 0; y < radius; y++)
			{

				for (int x = (int) radius; x < width - radius; x++)
				{
					colors [x, y] = color;
				}
			}

			for (int y = height - (int) radius; y < height; y++)
			{

				for (int x = (int) radius; x < width - radius; x++)
				{
					colors [x, y] = color;
				}
			}

			for (int y = (int) radius; y < height - radius; y++)
			{
				for (int x = 0; x < width; x++)
				{
					colors [x, y] = color;
				}
			}

			//Circles
			for (int i = 0; i < (int) radius * (int) radius; i++)
			{
				int x = i % (int) radius;
				int y = (int) i / (int) radius;
				if (Distance (x, y, radius, radius) < radius)
				{
					colors [x, y] = color;
				}
				else
				{
					colors [x, y] = Color.Transparent;
				}
			}

			for (int i = 0; i < (int) radius * (int) radius; i++)
			{
				int x = (width - (int) radius) + (i % (int) radius);
				int y = (int) i / (int) radius;
				if (Distance (x, y, width - radius, radius) < radius)
				{
					colors [x, y] = color;
				}
				else
				{
					colors [x, y] = Color.Transparent;
				}
			}

			for (int i = 0; i < (int) radius * (int) radius; i++)
			{
				int x = (width - (int) radius) + (i % (int) radius);
				int y = (height - (int) radius) + (int) i / (int) radius;
				if (Distance (x, y, width - radius, height - radius) < radius)
				{
					colors [x, y] = color;
				}
				else
				{
					colors [x, y] = Color.Transparent;
				}
			}

			for (int i = 0; i < (int) radius * (int) radius; i++)
			{
				int x = (i % (int) radius);
				int y = (height - (int) radius) + (int) i / (int) radius;
				if (Distance (x, y, radius, height - radius) < radius)
				{
					colors [x, y] = color;
				}
				else
				{
					colors [x, y] = Color.Transparent;
				}
			}
			/*Point topLeft = new Point(0, 0);
            Point bottomLeft = new Point(0, height);
            Point topRight = new Point(width, 0);
            Point bottomRight = new Point(width, height);
            Point[] points = new Point[4] { topLeft, topRight, bottomRight, bottomLeft };*/
			/*
            for (int i = 0; i < width * height; i++)
            {
                colors[i * 4] = color.R;
                colors[i * 4 + 1] = color.G;
                colors[i * 4 + 2] = color.B;
                colors[i * 4 + 3] = color.A;
            }

            for (int i = 0; i < (int)radius * (int)radius; i++)
            {
                int x = i % (int)width;
                int y = (int)i / (int)height;
                if (Distance(x, y, radius, radius) < radius)
                {
                    colors[i * 4] = color.R;
                    colors[i * 4 + 1] = color.G;
                    colors[i * 4 + 2] = color.B;
                    colors[i * 4 + 3] = color.A;
                }
                else
                {
                    colors[i * 4] = 0x00;
                    colors[i * 4 + 1] = 0x00;
                    colors[i * 4 + 2] = 0x00;
                    colors[i * 4 + 3] = 0x00;
                }
            }*/

			Texture2D rrec = new Texture2D (graphicsDevice, width, height);
			byte [,] bytes = ColorArrayToByte (colors);
			byte [] byte1D = Convert2DArrayTo1D (bytes);
			rrec.SetData (byte1D);
			return rrec;
		}

		public static Texture2D RoundedRectangle(GraphicsDevice graphicsDevice, Color color, Rectangle rectangle, double radius)
		{
			return RoundedRectangle (graphicsDevice, color, rectangle.Width, rectangle.Height, radius);
		}
	}
}

