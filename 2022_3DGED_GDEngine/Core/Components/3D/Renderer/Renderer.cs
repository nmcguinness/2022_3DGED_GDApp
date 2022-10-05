using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    /// <summary>
    /// Base class for all renderers (i.e. an object to render a mesh, model, animated model) used by the engine
    /// </summary>
    public abstract class Renderer : Component
    {
        /// <summary>
        /// Draw the content of the mesh
        /// </summary>
        public abstract void Draw(GraphicsDevice device, Effect effect);
    }
}