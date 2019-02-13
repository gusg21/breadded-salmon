using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Input
{
    class BreaddedMouseButton : BreaddedInput
    {
        public enum MOUSESTATE
        {
            LEFT,RIGHT,MIDDLE
        }
        MOUSESTATE checkMouse;
        MouseState state;
        MouseState prevState;
        public BreaddedMouseButton(MOUSESTATE checkMouse)
        {
            this.checkMouse = checkMouse;
        }
        public void Update(GameTime gameTime)
        {
            this.prevState = this.state;
            this.state = Mouse.GetState();
        }
        public override bool Check()
        {
            if(checkMouse == MOUSESTATE.LEFT)
            {
                return state.LeftButton == ButtonState.Pressed;
            }
            else if (checkMouse == MOUSESTATE.RIGHT)
            {
                return state.RightButton == ButtonState.Pressed;
            }
            else if (checkMouse == MOUSESTATE.MIDDLE)
            {
                return state.MiddleButton == ButtonState.Pressed;
            }
            return false;
        }

        public override bool Pressed()
        {
            if (checkMouse == MOUSESTATE.LEFT)
            {
                return state.LeftButton == ButtonState.Pressed && !(prevState.LeftButton == ButtonState.Pressed);
            }
            else if (checkMouse == MOUSESTATE.RIGHT)
            {
                return state.RightButton == ButtonState.Pressed && !(prevState.RightButton == ButtonState.Pressed);
            }
            else if (checkMouse == MOUSESTATE.MIDDLE)
            {
                return state.MiddleButton == ButtonState.Pressed && !(prevState.MiddleButton == ButtonState.Pressed);
            }
            return false;
        }

        public override bool Released()
        {
            if (checkMouse == MOUSESTATE.LEFT)
            {
                return !(state.LeftButton == ButtonState.Pressed) && (prevState.LeftButton == ButtonState.Pressed);
            }
            else if (checkMouse == MOUSESTATE.RIGHT)
            {
                return !(state.RightButton == ButtonState.Pressed) && (prevState.RightButton == ButtonState.Pressed);
            }
            else if (checkMouse == MOUSESTATE.MIDDLE)
            {
                return !(state.MiddleButton == ButtonState.Pressed) && (prevState.MiddleButton == ButtonState.Pressed);
            }
            return false;
        }
    }
}
