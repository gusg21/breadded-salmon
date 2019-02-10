using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Comora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
	public class BSGame : Game
	{
		protected GraphicsDeviceManager graphics;
		protected SpriteBatch spriteBatch;

		protected GameState currentState;
		public Dictionary<string, GameState> states = new Dictionary<string, GameState> ();

		protected bool Debug = true;

		public BSGame(Dictionary<string, GameState> states, string initial) : base()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			this.states = states;
			currentState = this.states[initial];
			foreach (GameState state in states.Values)
			{
				state.Parent = this;
			}
		}

		protected override void Initialize()
		{
			base.Initialize ();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);

			currentState.LoadContent (Content);
		}

		protected override void Update(GameTime gameTime)
		{
			if ((GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape)) && Debug)
				Exit ();

			currentState.Update (gameTime);

			base.Update (gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear (Color.Black);

			spriteBatch.Begin (currentState.camera, samplerState: SamplerState.PointClamp);

			currentState.Draw (spriteBatch);

			spriteBatch.End ();

			if (currentState.camera != null)
				currentState.camera.Debug.Draw (spriteBatch, Vector2.Zero);

			base.Draw (gameTime);
		}
	}
}
