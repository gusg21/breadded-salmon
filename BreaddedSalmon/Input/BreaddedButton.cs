using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Input
{
    class BreaddedButton : BreaddedInput
    {
        public List<BreaddedInput> targets;
        private float firstRepeatDelay;
        private float multiRepeatDelay;
        public BreaddedButton()
        {
            targets = new List<BreaddedInput>();
        }
        public BreaddedButton(List<BreaddedInput> _targets)
        {
            targets = new List<BreaddedInput>(_targets);
        }
        public override void Update()
        {
            foreach (var target in targets)
            {
                target.Update();

            }

        }

        public override bool Pressed()
        {
            foreach (var target in targets)
            {
                if (target.Pressed())
                {
                    return true;
                }
            }
            return false;
        }

        public override bool Released()
        {
            foreach (var target in targets)
            {
                if (target.Released())
                {
                    return true;
                }
            }
            return false;
        }

        public override bool Check()
        {
            foreach (var target in targets)
            {
                if (target.Check())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
