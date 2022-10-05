using Microsoft.Xna.Framework;

namespace GD.Engine
{
    /// <summary>
    /// Stores the fields required to represent a Camera
    /// </summary>
    public class Camera : Component
    {
        private Matrix view;
        private Matrix projection;
        public Matrix View => view;
        public Matrix Projection => projection;

        public Camera()
        {
            // view = Matrix.CreateLookAt(/*where do we get transform parameters from?*/);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.Pi / 2, 16 / 10.0f, 0.1f, 1000);
        }
    }
}