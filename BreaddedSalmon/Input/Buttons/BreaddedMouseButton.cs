using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BS.Input
{
	public class BreaddedMouseButton : BreaddedInput
	{
		public enum MouseButton
		{
			LEFT, RIGHT, MIDDLE
		}

		MouseButton checkMouse;
		MouseState state;
		MouseState prevState;

		public BreaddedMouseButton(MouseButton checkMouse)
		{
			this.checkMouse = checkMouse;
		}

		public override void Update(GameTime gameTime)
		{
			prevState = state;
			state = Mouse.GetState ();
		}

		public override bool Check()
		{
			if (checkMouse == MouseButton.LEFT)
			{
				return state.LeftButton == ButtonState.Pressed;
			}
			else if (checkMouse == MouseButton.RIGHT)
			{
				return state.RightButton == ButtonState.Pressed;
			}
			else if (checkMouse == MouseButton.MIDDLE)
			{
				return state.MiddleButton == ButtonState.Pressed;
			}
			return false;
		}

		public override bool Pressed()
		{
			if (checkMouse == MouseButton.LEFT)
			{
				return state.LeftButton == ButtonState.Pressed && !(prevState.LeftButton == ButtonState.Pressed);
			}
			else if (checkMouse == MouseButton.RIGHT)
			{
				return state.RightButton == ButtonState.Pressed && !(prevState.RightButton == ButtonState.Pressed);
			}
			else if (checkMouse == MouseButton.MIDDLE)
			{
				return state.MiddleButton == ButtonState.Pressed && !(prevState.MiddleButton == ButtonState.Pressed);
			}
			return false;
		}

		public override bool Released()
		{
			if (checkMouse == MouseButton.LEFT)
			{
				return !(state.LeftButton == ButtonState.Pressed) && (prevState.LeftButton == ButtonState.Pressed);
			}
			else if (checkMouse == MouseButton.RIGHT)
			{
				return !(state.RightButton == ButtonState.Pressed) && (prevState.RightButton == ButtonState.Pressed);
			}
			else if (checkMouse == MouseButton.MIDDLE)
			{
				return !(state.MiddleButton == ButtonState.Pressed) && (prevState.MiddleButton == ButtonState.Pressed);
			}
			return false;
		}
	}
}
