using BS.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Particles
{
    public class BreaddedParticleType
    { 
        public enum ColorModes { Static, Choose, Blink, Fade}
        public enum FadeModes { None, Liniar, Late, InAndOut }
        public enum RotationModes { None, Random, SameAsDirection}
        public enum ScaleModes { None, Liniar, Wiggle}

        public enum ParticleTextureType { Sprite, Texture2D, MultiSprite, MultiTexture2D}
        public ParticleTextureType mode;

        public enum AnimationMode { Normal, RandomFrame }


        float directionRange;


        BreaddedParticleType deathParticle = null;

        Color color;
        List<Texture2D> textures;
        List<BreaddedAnimation> animations;

        public BreaddedParticleType(float scale, float speed, float direction, float gravity, float rotation, float spin, float life, Color color, BreaddedParticleType deathParticle = null)
        {
            this.deathParticle = deathParticle;
            this.color = color;
        }

        public void Create(BreaddedParticle Particle, Vector2 position, float direction , Color color)
        {

        }
    }
}
