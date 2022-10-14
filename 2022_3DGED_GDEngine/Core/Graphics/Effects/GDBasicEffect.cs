﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    /// <summary>
    /// Wrapper class for a BasicEffect to integrate its use into the engine
    /// </summary>
    public class GDBasicEffect : IEffect
    {
        private BasicEffect effect;

        public GDBasicEffect(Effect effect)
        {
            this.effect = effect as BasicEffect;
        }

        public void SetWorld(Matrix world)
        {
            effect.World = world;
        }

        public void SetCamera(Camera camera)
        {
            effect.View = camera.View;
            effect.Projection = camera.Projection;
        }

        public void SetMaterial(Material material)
        {
            effect.Texture = material.Diffuse;
            effect.Alpha = material.Alpha;
        }

        public void Apply()
        {
            effect.CurrentTechnique.Passes[0].Apply();
        }
    }
}