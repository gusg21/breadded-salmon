using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace BS.Audio
{
	public class BreaddedJukebox
	{
		public Dictionary<string, AudioLayer> audioLayers;
		public Dictionary<string, SoundEffect> songs;

		public BreaddedJukebox()
		{
			songs = new Dictionary<string, SoundEffect> ();
			audioLayers = new Dictionary<string, AudioLayer> ();
		}

		public void AddLayer(string name)
		{
			audioLayers.Add (name, new AudioLayer (name));
		}

		public void AddSong(SoundEffect song, string songName)
		{
			songs.Add (songName, song);
		}

		public void PlaySong(string songName, string layerName)
		{
			audioLayers [layerName].Play (songs [songName]);
		}

		public void FadeSong(string fadeToSong, string layerName, float duration)
		{
			audioLayers [layerName].FadeTo (songs [fadeToSong], duration);
		}

		public void Update(GameTime gameTime)
		{
			foreach (KeyValuePair<string, AudioLayer> layer in audioLayers)
			{
				layer.Value.Update (gameTime);
			}
		}

		public void Dispose()
		{
			foreach (KeyValuePair<string, AudioLayer> layer in audioLayers)
			{
				layer.Value.Dispose ();
			}
		}

		public void PartysOver()
		{
			Dispose ();
		}
	}

	public class AudioLayer
	{
		public SoundEffectInstance oldSong; // for fading
		public SoundEffectInstance currentSong;
		public float fadeTimeLeft = -1f;
		public float currentFadeDuration = 0f;
		public string name;

		public AudioLayer(string name)
		{
			this.name = name;
		}

		public void Play(SoundEffect song)
		{
			if (currentSong != null)
				currentSong.Stop ();
			currentSong = song.CreateInstance ();
			currentSong.Play ();
		}

		public void Dispose()
		{
			currentSong.Dispose ();
			oldSong.Dispose ();
		}

		public void FadeTo(SoundEffect to, float duration)
		{
			fadeTimeLeft = duration;
			currentFadeDuration = duration;
			oldSong = currentSong;
			currentSong = to.CreateInstance ();
			currentSong.Volume = 0f;
			oldSong.Volume = 1f;
			currentSong.Play ();
		}

		public void Update(GameTime gameTime)
		{
			fadeTimeLeft -= (float) gameTime.ElapsedGameTime.TotalSeconds;
			if (fadeTimeLeft < 0)
			{
				fadeTimeLeft = 0;
				if (oldSong != null)
					oldSong.Stop ();
			}

			fadeTimeLeft = (fadeTimeLeft < 0) ? 0 : fadeTimeLeft;

			if (currentSong != null)
			{
				currentSong.Volume = MathHelper.Lerp (1, 0, fadeTimeLeft / currentFadeDuration);
			}

			if (oldSong != null)
			{
				oldSong.Volume = MathHelper.Lerp (0, 1, fadeTimeLeft / currentFadeDuration);

			}
		}
	}
}
