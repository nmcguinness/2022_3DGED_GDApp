﻿using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    public class ModelMesh : Mesh
    {
        private Model model;

        public ModelMesh(GraphicsDevice graphicsDevice, Model model)
            : base(graphicsDevice)
        {
            this.model = model;
        }

        protected override void CreateGeometry()
        {
            //extracts from the model the vertices and indices
            model.ExtractData<VertexPositionNormalTexture>(ref graphicsDevice,
                out vertices, out indices);
        }
    }
}