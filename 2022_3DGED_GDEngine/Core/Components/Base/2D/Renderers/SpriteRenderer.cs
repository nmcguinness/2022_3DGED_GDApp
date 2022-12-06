using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace GD.Engine
{
    /// <summary>
    /// Orchestrates the drawing/rendering of an object
    /// </summary>
    public class SpriteRenderer : Component
    {
        #region Fields

        private SpriteMaterial material;  //textures, alpha
        private UIElement uiElement;      //text, texture

        #endregion Fields

        #region Properties

        public SpriteMaterial Material { get => material; set => material = value; }
        public UIElement UiElement { get => uiElement; set => uiElement = value; }

        #endregion Properties

        #region Constructors

        public SpriteRenderer(SpriteMaterial material,
         UIElement uiElement)
        {
            this.material = material;
            this.uiElement = uiElement;
        }

        #endregion Constructors

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            uiElement.Draw(spriteBatch, transform, material);
        }
    }
}