using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    public class Material
    {
        private Texture2D diffuse;
        private float alpha;

        public Texture2D Diffuse { get => diffuse; protected set => diffuse = value; }
        public float Alpha { get => alpha; protected set => alpha = value; }

        public Material(Texture2D diffuse, float alpha)
        {
            this.diffuse = diffuse;
            this.alpha = alpha;
        }
    }
}