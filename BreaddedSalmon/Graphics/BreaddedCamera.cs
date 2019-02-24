using System;
using Microsoft.Xna.Framework;

namespace BS
{
	public class BreaddedCamera
	{
		public Matrix Transform
		{
			get
			{
				Matrix m = Matrix.CreateTranslation (-Position.X, -Position.Y, 0) *
										 Matrix.CreateRotationZ (Rotation) *
										 Matrix.CreateScale (new Vector3 (zoom, zoom, 1)) *
										 Matrix.CreateTranslation (new Vector3 (ViewportWidth * 0.5f, ViewportHeight * 0.5f, 0));

				return m;
			}
		}

		public Vector2 Position
		{
			get
			{
				return InternalPosition + PositionOffset;
			}
			private set { }
		}
		private Vector2 InternalPosition = new Vector2 (8, 8);
		private Vector2 PositionOffset = Vector2.Zero;

        public void MoveTo(Vector2 vector2)
        {
            InternalPosition = vector2;
        }

        public int ViewportWidth;
		public int ViewportHeight;

		public float Rotation = 0f;
		private float zoom = 2f;
		public float Zoom
		{
			set
			{
				zoom = (value > 0) ? zoom : 0;
			}
		}

		public BreaddedCamera(int viewportWidth, int viewportHeight)
		{
			ViewportWidth = viewportWidth;
			ViewportHeight = viewportHeight;
		}
	}
}
