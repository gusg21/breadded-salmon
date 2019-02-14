using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS
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

		public void FadeSong(string fadeToSong, string layerName, double duration)
		{

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

		public void FadeTo(SoundEffect to, float duration)
		{
			fadeTimeLeft = duration;
			currentFadeDuration = duration;
			oldSong = currentSong;
			currentSong = to.CreateInstance ();
			currentSong.Volume = 0f;
			oldSong.Volume = 1f;
		}

		public void Update(GameTime gameTime)
		{
			fadeTimeLeft -= gameTime.GetElapsedSeconds ();
			if (fadeTimeLeft < 0)
			{ }
			fadeTimeLeft = (fadeTimeLeft < 0) ? 0 : fadeTimeLeft;

			currentSong.Volume = MathHelper.Lerp (0, 1, fadeTimeLeft / currentFadeDuration);
			oldSong.Volume = MathHelper.Lerp (1, 0, fadeTimeLeft / currentFadeDuration);
		}
	}
}
