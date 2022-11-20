using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GD.Engine
{
    public class AudioEmitterBehaviour : Component
    {
        private AudioEmitter audioEmitter;

        public override void Update(GameTime gameTime)
        {
            if (transform == null || audioEmitter == null)
                return;

            audioEmitter.Position = transform.translation;
            audioEmitter.Up = transform.World.Up;
            audioEmitter.Forward = transform.World.Forward;
            //emitter.Velocity = transform.Velocity;
        }
    }
}