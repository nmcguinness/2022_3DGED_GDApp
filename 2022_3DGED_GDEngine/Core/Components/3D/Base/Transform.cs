using Microsoft.Xna.Framework;

namespace GD.Engine
{
    /// <summary>
    /// Store and manage transform values (position, rotation, scale)
    /// </summary>
    public class Transform : Component
    {
        /// <summary>
        /// Scale relative to the parent transform
        /// </summary>
        public Vector3 scale;

        /// <summary>
        /// Rotation relative to the parent transform
        /// </summary>
        public Vector3 rotation;

        /// <summary>
        /// Translation relative to the parent transform
        /// </summary>
        public Vector3 translation;

        public Matrix World //ISRoT
        {
            get
            {
                //TODO - improve so not always calculated for when object does not move
                return Matrix.Identity * Matrix.CreateScale(scale)
                    * Orientation * Matrix.CreateTranslation(translation);
            }
        }

        public Matrix Orientation
        {
            get
            {
                //TODO - improve so not always calculated for when object does not rotate
                return Matrix.CreateRotationX(rotation.X)
                    * Matrix.CreateRotationY(rotation.Y)
                    * Matrix.CreateRotationZ(rotation.Z);
            }
        }

        public Transform(Vector3? scale, Vector3? rotation, Vector3? translation)
        {
            this.scale = scale.HasValue ? scale.Value : Vector3.One;
            this.rotation = rotation.HasValue ? rotation.Value : Vector3.Zero;
            this.translation = translation.HasValue ? translation.Value : Vector3.Zero;
        }

        //TODO - clone etc
    }
}