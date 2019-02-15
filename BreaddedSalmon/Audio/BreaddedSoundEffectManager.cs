using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Audio
{
    class BreaddedSoundEffectManager
    {
        public Dictionary<string, SoundEffect> sounds;
        public BreaddedSoundEffectManager()
        {
            sounds = new Dictionary<string, SoundEffect>();
        }

        public void AddSound(SoundEffect sound, string soundName)
        {
            sounds.Add(soundName, sound);
        }

        public void PlaySound(string songName, float volume = 1, float pan = 0, float pitch = 1)
        {
            SoundEffectInstance effect = sounds[songName].CreateInstance();
            effect.Volume = volume;
            effect.Pan = pan;
            effect.Pitch = pitch;
            effect.Play();
        }

        public void Dispose()
        {
            foreach(KeyValuePair<string, SoundEffect> sound in sounds)
            {
                sound.Value.Dispose();
            }
        }

        public void Dispose(string soundName)
        {
            sounds[soundName].Dispose();
        }
    }
}
