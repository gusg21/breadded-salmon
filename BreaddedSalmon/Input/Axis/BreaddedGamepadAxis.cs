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
        public enum Axes
        {
            LEFTX, LEFTY, RIGHTX, RIGHTY, LEFT_TRIGGER, RIGHT_TRIGGER
        }

        Axes axis;
        PlayerIndex gamepadID;

        public BreaddedGamepadAxis(Axes axis, PlayerIndex gamepadID)
        {
            this.axis = axis;
			this.gamepadID = gamepadID;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override float Get()
        {
            if (axis == Axes.LEFTX)
            {
                return GamePad.GetState(gamepadID).ThumbSticks.Left.X;
            }
            else if (axis == Axes.LEFTY)
            {
                return GamePad.GetState(gamepadID).ThumbSticks.Left.Y;
            }
            else if (axis == Axes.RIGHTX)
            {
                return GamePad.GetState(gamepadID).ThumbSticks.Right.X;
            }
            else if (axis == Axes.RIGHTY)
            {
                return GamePad.GetState(gamepadID).ThumbSticks.Right.Y;
            }
            else if (axis == Axes.LEFT_TRIGGER)
            {
                return GamePad.GetState(gamepadID).Triggers.Left;
            }
            else if (axis == Axes.RIGHT_TRIGGER)
            {
                return GamePad.GetState(gamepadID).Triggers.Right;
            }

            return 0;
        }
    }
}
