using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using BS.Input;

namespace BS.Key
{
    class BreaddedKey : BreaddedInput
    {
        public Keys key;
        char? norm;
        char? shift;
        char? mod;
        public bool prevState;
        public bool currState;
        public bool isPressed = false;
        public bool isReleased = false;


        public BreaddedKey(Keys key, char? norm, char? shift = null, char? mod = null)
        {
            this.key = key;
            this.norm = norm;
            this.shift = shift;
            this.mod = mod;
        }
        public char? Value(bool? shifted, bool? alt)
        {
            if (shifted.HasValue)
            {
                if (shifted.Value && this.shift.HasValue)
                {
                    return this.shift.Value;
                }
            }
            if (alt.HasValue)
            {
                if (alt.Value && this.mod.HasValue)
                {
                    return this.mod.Value;
                }
            }
            if (this.norm.HasValue)
            {
                return this.norm.Value;

            }

            return null;

        }
        public void Update(GameTime gameTime, KeyboardState state)
        {

            prevState = currState;
            currState = state.IsKeyDown(key);
        }
        public override bool Pressed()
        {
            return currState && !prevState;
        }
        public override bool Released()
        {
            return !currState && prevState;
        }
        public override bool Check()
        {
            return currState;
        }
    }
}
