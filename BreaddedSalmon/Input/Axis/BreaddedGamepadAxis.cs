using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BS.Input.Axis
{
    class BreaddedGamepadAxis : BreaddedGenericAxis
    {
        public enum AXES
        {
            LEFTX, LEFTY, RIGHTX, RIGHTY, LEFT_TRIGGER, RIGHT_TRIGGER
        }
        AXES axis;
        int gamepadID;
        public BreaddedGamepadAxis(AXES axis, int gamepadID)
        {
            this.axis = axis;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override float Get()
        {
            if (axis == AXES.LEFTX)
            {
                return GamePad.GetState(gamepadID).ThumbSticks.Left.X;
            }
            else if (axis == AXES.LEFTY)
            {
                return GamePad.GetState(gamepadID).ThumbSticks.Left.Y;
            }
            else if (axis == AXES.RIGHTX)
            {
                return GamePad.GetState(gamepadID).ThumbSticks.Right.X;
            }
            else if (axis == AXES.RIGHTY)
            {
                return GamePad.GetState(gamepadID).ThumbSticks.Right.Y;
            }
            else if (axis == AXES.LEFT_TRIGGER)
            {
                return GamePad.GetState(gamepadID).Triggers.Left;
            }
            else if (axis == AXES.RIGHT_TRIGGER)
            {
                return GamePad.GetState(gamepadID).Triggers.Right;
            }
            return 0;
        }
    }
}
