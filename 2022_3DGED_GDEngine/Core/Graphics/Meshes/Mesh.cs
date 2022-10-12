using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    /// <summary>
    /// Stores the vertices and indices and creates the vertexbuffer and indexbuffer for a mesh
    /// </summary>
    public abstract class Mesh : Component
    {
        #region Fields

        protected VertexPositionNormalTexture[] vertices;
        protected ushort[] indices;
        protected VertexBuffer vertexBuffer;
        protected IndexBuffer indexBuffer;

        #endregion Fields

        #region Constructors

        public Mesh(GraphicsDevice graphicsDevice)
        {
            //set up the position, normal, texture UVs etc
            CreateGeometry();

            //set up the buffers on VRAM with the vertex array and index array
            CreateBuffers(graphicsDevice);
        }

        #endregion Constructors

        protected abstract void CreateGeometry();

        /// <summary>
        /// Reserve space on VRAM and move the vertex and index data to VRAM before first Draw()
        /// </summary>
        /// <param name="graphicsDevice"></param>
        private void CreateBuffers(GraphicsDevice graphicsDevice)
        {
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionNormalTexture), vertices.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(vertices);

            indexBuffer = new IndexBuffer(graphicsDevice, typeof(ushort), indices.Length, BufferUsage.WriteOnly);
            indexBuffer.SetData(indices);
        }
    }
}