using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Engine
{
    public class UITextureElement : UIElement
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch,
            Transform transform, SpriteMaterial material)
        {
            var translation = transform.Translation;
            var scale = transform.Scale;

            spriteBatch.Draw(material.Diffuse,
                translation.To2D(),
                material.SourceRectangle,
                material.DiffuseColor,
                //TODO - remember this is degrees!
                transform.Rotation.Z,
                material.Origin,
                scale.To2D(),
                material.SpriteEffects,
                material.LayerDepth);
        }
    }

    public interface UIElement
    {
        //no common state information?
        public void Draw(GameTime gameTime,
            SpriteBatch spriteBatch,
            Transform transform,
            SpriteMaterial material);
    }
}