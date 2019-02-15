using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BS.Input
{
    class BreaddedVirtualAxis : BreaddedGenericAxis
    {
        BreaddedButton highButton;
        BreaddedButton lowButton;

        private float highValue;
        private float lowValue;
        private float both;

        public BreaddedVirtualAxis(BreaddedButton highButton, BreaddedButton lowButton, float highValue, float lowValue, float both)
        {
            this.highButton = highButton;
            this.lowButton = lowButton;
            this.highValue = highValue;
            this.lowValue = lowValue;
            this.both = both;
        }
        public override void Update(GameTime gameTime)
        {
            highButton.Update(gameTime);
            lowButton.Update(gameTime);
        }
        public override float Get()
        {
            if(highButton.Check() && lowButton.Check())
            {
                return both;
            }
            else if (highButton.Check())
            {
                return highValue;
            }
            else if (lowButton.Check())
            {
                return lowValue;
            }
            return 0;
        }
    }
}
