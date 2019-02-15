using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Input
{
    abstract class BreaddedGenericAxis
    {
        public virtual void Update(GameTime gameTime)
        {

        }
        public abstract float Get();
    }
}
