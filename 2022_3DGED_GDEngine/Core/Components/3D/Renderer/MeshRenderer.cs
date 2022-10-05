using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    /// <summary>
    /// Draws a user-defined array of vertices and indices
    /// </summary>
    public class MeshRenderer : Renderer
    {
        protected Mesh mesh;

        public MeshRenderer(Mesh mesh)
        {
            this.mesh = mesh;
        }

        public override void Draw(GraphicsDevice device, Effect effect)
        {
        }
    }
}