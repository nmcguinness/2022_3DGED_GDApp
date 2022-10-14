using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    public class Renderer : Component
    {
        private IEffect effect;
        private Material material;
        private Mesh mesh;

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