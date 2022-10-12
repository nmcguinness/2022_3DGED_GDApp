using Microsoft.Xna.Framework;

namespace GD.Engine
{
    /// <summary>
    /// Stores the fields required to represent a Camera
    /// </summary>
    public class Camera : Component
    {
        #region Fields

        private float fieldOfView;
        private float aspectRatio;
        private float nearPlaneDistance;
        private float farPlaneDistance;

        #endregion Fields

        #region Properties

        public float FieldOfView { get => fieldOfView; set => fieldOfView = value; }
        public float AspectRatio { get => aspectRatio; set => aspectRatio = value; }
        public float NearPlaneDistance { get => nearPlaneDistance; set => nearPlaneDistance = value >= 0 ? value : 0.1f; }
        public float FarPlaneDistance { get => farPlaneDistance; set => farPlaneDistance = value >= 0 ? value : 100; }

        public Matrix View
        {
            get
            {
                return Matrix.CreateLookAt(transform.translation, transform.translation + transform.World.Forward, transform.World.Up);
            }
        }

        public Matrix Projection
        {
            get
            {
                return Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);
            }
        }

        #endregion Properties

        #region Constructors

        public Camera(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            this.fieldOfView = fieldOfView;
            this.aspectRatio = aspectRatio;
            this.nearPlaneDistance = nearPlaneDistance;
            this.farPlaneDistance = farPlaneDistance;
        }

        #endregion Constructors
    }
}