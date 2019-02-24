using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BS
{
	public class GameObjectGroup : GameObject
	{
		public List<GameObject> children = new List<GameObject> ();
		public GameState Parent;

		public GameObjectGroup(GameState parent)
		{
			Parent = parent;
		}

		public void Add(GameObject child)
		{
			children.Add (child);
			child.Parent = this;
		}

		internal int DepthSort(GameObject a, GameObject b)
		{
			if (a.depth > b.depth)
				return 1;
			else if (a.depth == b.depth)
				return 0;
			else if (a.depth > b.depth)
				return -1;
			else
				Console.WriteLine ("Sorting is broken");

			return 0;
		}

		public void Sort()
		{
			children.Sort (new Comparison<GameObject> (DepthSort));
		}

		public new void LoadContent(ContentManager content)
		{
			foreach (GameObject @object in children)
			{
				@object.LoadContent (content);
			}
		}

		public new void Update(GameTime gameTime)
		{
			foreach (GameObject @object in children)
			{
				if (@object.alive)
					@object.Update (gameTime);

				if (!@object.exists)
					children.Remove (@object);
			}

			Sort ();
		}

		public new void Draw(SpriteBatch batch)
		{
			foreach (GameObject @object in children)
			{
				@object.Draw (batch);
			}
		}
	}
}
