using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BS.Input
{
	public class BreaddedGamepadButton : BreaddedInput
	{
		bool currentState;
		Buttons button;
		bool prevState;
		int gamePadID;

		public BreaddedGamepadButton(Buttons button, int gamePadID)
		{
			this.gamePadID = gamePadID;
			this.button = button;
		}

		public override void Update(GameTime gameTime)
		{
			prevState = this.currentState;
			currentState = GamePad.GetState (gamePadID).IsButtonDown (button);
		}

		public override bool Check()
		{
			if (currentState)
			{
				return true;
			}
			return false;
		}

		public override bool Pressed()
		{
			return this.currentState && !(this.prevState);

		}

		public override bool Released()
		{
			return !(this.currentState) && (this.prevState);
		}
	}
}
