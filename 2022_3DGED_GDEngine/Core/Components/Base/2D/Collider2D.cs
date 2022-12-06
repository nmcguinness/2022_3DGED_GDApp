using GD.Engine.Globals;
using GD.Engine.Inputs;
using Microsoft.Xna.Framework;

namespace GD.Engine
{
    public class Collider2D : Component
    {
        #region Fields

        private Rectangle bounds;

        #endregion Fields

        #region Properties

        public Rectangle Bounds { get => bounds; set => bounds = value; }

        #endregion Properties

        public Collider2D(GameObject gameObject, SpriteRenderer spriteRenderer)
        {
            var width = spriteRenderer.Material.Diffuse.Width;
            var height = spriteRenderer.Material.Diffuse.Height;

            bounds = new Rectangle(
              (int)gameObject.Transform.Translation.X,
              (int)gameObject.Transform.Translation.Y,
             (int)(width * gameObject.Transform.Scale.X),
              (int)(height * gameObject.Transform.Scale.Y));
        }

        public override void Update(GameTime gameTime)
        {
            CheckMouseOver();
            base.Update(gameTime);
        }

        public virtual void CheckMouseOver()
        {
            if (bounds.Intersects(Input.Mouse.Bounds))
            {
                //check for over
                HandleMouseOver();
                //check for clicks
                if (Input.Mouse.WasJustClicked(Inputs.MouseButton.Left))
                    HandleMouseClick(Inputs.MouseButton.Left);
                else if (Input.Mouse.WasJustClicked(Inputs.MouseButton.Middle))
                    HandleMouseClick(Inputs.MouseButton.Middle);
                else if (Input.Mouse.WasJustClicked(Inputs.MouseButton.Right))
                    HandleMouseClick(Inputs.MouseButton.Right);
            }
        }

        public virtual void HandleMouseClick(MouseButton mouseButton)
        {
        }

        public virtual void HandleMouseOver()
        {
        }
    }
}