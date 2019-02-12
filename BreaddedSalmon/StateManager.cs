using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BS
{
	public class StateManager
	{
		public Dictionary<string, GameState> states = new Dictionary<string, GameState> ();
		public Dictionary<string, GameSubState> substates = new Dictionary<string, GameSubState> ();

		private string currentStateId;
		public GameState CurrentState
		{
			get
			{
				return states [currentStateId];
			}
		}

		private string currentSubStateId;
		public GameSubState CurrentSubState
		{
			get
			{
				try
				{
					return substates [currentSubStateId];
				}
				catch
				{
					return GameSubState.Default;
				}
			}
		}
		public bool SubstateOn { get; private set; } = false;

		public Matrix? TransformMatrix;
		public SamplerState samplerState = SamplerState.PointClamp;

		public StateManager(Dictionary<string, GameState> states, string initial, Dictionary<string, GameSubState> substates)
		{
			this.states = states;
			this.substates = substates;

			foreach (string id in states.Keys)
			{
				states [id].ID = id;
				states [id].Parent = this;
			}

			foreach (string id in substates.Keys)
			{
				substates [id].ID = id;
				substates [id].Parent = this;
			}

			currentStateId = initial;
			CurrentState.Enter (null);
		}

		public void Update(GameTime gameTime)
		{
			if (!SubstateOn && !CurrentSubState.Preemptive)
				CurrentState.Update (gameTime);

			if (SubstateOn)
			{
				CurrentSubState.Update (gameTime);

				if (CurrentSubState.IsFinished ())
					SubstateOn = false;
			}
		}

		public void Draw(SpriteBatch batch)
		{
			Console.WriteLine (TransformMatrix == null ? "null" : TransformMatrix.ToString());

			if (TransformMatrix == null)
				batch.Begin (samplerState: samplerState);
			else
				batch.Begin (transformMatrix: TransformMatrix, samplerState: samplerState);

			CurrentState.Draw (batch);

			if (SubstateOn)
				CurrentSubState.Draw (batch);

			batch.End ();
		}

		public void SwitchState(string to)
		{
			string oldStateId = CurrentState.ID;
			CurrentState.Leave (to);
			currentStateId = to;
			CurrentState.Enter (oldStateId);
		}

		public void TriggerSubstate(string id)
		{
			currentSubStateId = id;
			SubstateOn = true;
			CurrentSubState.Enter ();
		}
	}
}
