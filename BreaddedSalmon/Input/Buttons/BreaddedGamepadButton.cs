using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Input
{
    class BreaddedGamepadButton : BreaddedInput
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
        public void Update(GameTime gameTime)
        {
            this.prevState = this.currentState;
            currentState = GamePad.GetState(gamePadID).IsButtonDown(button);
        }
        public override bool Check()
        {
            if(this.currentState)
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
