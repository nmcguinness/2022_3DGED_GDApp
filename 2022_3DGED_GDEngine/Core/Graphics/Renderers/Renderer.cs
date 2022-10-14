using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    /// <summary>
    /// Orchestrates the drawing/rendering of an object
    /// </summary>
    public class Renderer : Component
    {
        private IEffect effect; //effect
        private Material material;  //textures, alpha
        private Mesh mesh;  //vertices and indices

        public Renderer(IEffect effect, Material material, Mesh mesh)
        {
            this.effect = effect;
            this.material = material;
            this.mesh = mesh;
        }

        public virtual void Draw(GraphicsDevice graphicsDevice, Camera camera)
        {
            //set WVP as always
            effect.SetWorld(transform.World);
            effect.SetCamera(camera);
            effect.SetMaterial(material);

            //apply all settings
            effect.Apply();

            //draw the object
            mesh.Draw(graphicsDevice);
        }
    }
}