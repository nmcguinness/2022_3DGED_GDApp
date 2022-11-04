using GD.Engine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace GD.Engine.Utilities
{
    public abstract class SpriteBatchInfo
    {
        protected SpriteBatch spriteBatch;
        protected SpriteFont spriteFont;
        protected string label;
        protected Color color;

        protected SpriteBatchInfo(SpriteBatch spriteBatch, SpriteFont spriteFont, string label, Color color)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.label = label;
            this.color = color;
        }

        public virtual void Draw(string text, Vector2 position)
        {
        }

        public virtual void Draw(Vector2 position)
        {
        }
    }

    /// <summary>
    /// Add a text label to the performance UI
    /// </summary>
    public class TextInfo : SpriteBatchInfo
    {
        public TextInfo(SpriteBatch spriteBatch, SpriteFont spriteFont, string label, Color color) : base(spriteBatch, spriteFont, label, color)
        {
        }

        public override void Draw(Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, $"{label}", position, color);
        }
    }

    /// <summary>
    /// Adds FPS info to the performance UI
    /// </summary>
    public class FPSInfo : SpriteBatchInfo
    {
        public FPSInfo(SpriteBatch spriteBatch, SpriteFont spriteFont, string label, Color color) : base(spriteBatch, spriteFont, label, color)
        {
        }

        public override void Draw(string text, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, $"{label}{text}", position, color);
        }
    }

    /// <summary>
    /// Adds active camera position info to the performance UI
    /// </summary>
    public class CameraPositionInfo : SpriteBatchInfo
    {
        public CameraPositionInfo(SpriteBatch spriteBatch, SpriteFont spriteFont, string label, Color color) : base(spriteBatch, spriteFont, label, color)
        {
        }

        public override void Draw(Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, $"{label}{Application.CameraManager.ActiveCamera.transform.translation.GetNewRounded(1)}", position, color);
        }
    }

    /// <summary>
    /// Adds active camera rotation info to the performance UI
    /// </summary>
    public class CameraRotationInfo : SpriteBatchInfo
    {
        public CameraRotationInfo(SpriteBatch spriteBatch, SpriteFont spriteFont, string label, Color color) : base(spriteBatch, spriteFont, label, color)
        {
        }

        public override void Draw(Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, $"{label}{Application.CameraManager.ActiveCamera.transform.rotation.GetNewRounded(1)}", position, color);
        }
    }

    /// <summary>
    /// Adds active camera name info to the performance UI
    /// </summary>
    public class CameraNameInfo : SpriteBatchInfo
    {
        public CameraNameInfo(SpriteBatch spriteBatch, SpriteFont spriteFont, string label, Color color) : base(spriteBatch, spriteFont, label, color)
        {
        }

        public override void Draw(Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, $"{label}{Application.CameraManager.ActiveCameraName}", position, color);
        }
    }

    /// <summary>
    /// Adds active camera name info to the performance UI
    /// </summary>
    public class ObjectInfo : SpriteBatchInfo
    {
        public ObjectInfo(SpriteBatch spriteBatch, SpriteFont spriteFont, string label, Color color) : base(spriteBatch, spriteFont, label, color)
        {
        }

        public override void Draw(Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, $"{label}{Application.SceneManager.ActiveScene.GetPerfStats()}", position, color);
        }
    }
}