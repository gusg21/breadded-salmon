using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
	public class GameSubState : GameState
	{
		public bool Preemptive = false;

		public virtual void Enter() { }

		public virtual bool IsFinished()
		{
			return true;
		}

		public static readonly GameSubState Default = new GameSubState ();
	}
}
