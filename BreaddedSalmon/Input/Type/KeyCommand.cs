using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Input.Type
{
    abstract class KeyCommand
    {
        public virtual bool IsFinished()
        {
            return false;
        }

        public virtual void Update()
        {
            if (IsFinished() == true){
                End();
            }
            else
            {
                Run();
            }
        }

        public virtual void Run()
        {

        }
        public virtual void End()
        {

        }

        public virtual void Start()
        {

        }
    
    }
}
