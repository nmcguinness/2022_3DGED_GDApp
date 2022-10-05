using Microsoft.Xna.Framework;

namespace GD.Engine
{
    /// <summary>
    /// Store and manage transform values (position, rotation, scale) and provides transform operations e.g. translation, rotation and scale
    /// </summary>
    public class Transform : Component
    {
        /// <summary>
        /// Scale relative to the parent transform
        /// </summary>
        private Vector3 localScale;

        /// <summary>
        /// Rotation relative to the parent transform
        /// </summary>
        private Vector3 localRotation;

        /// <summary>
        /// Translation relative to the parent transform
        /// </summary>
        private Vector3 localTranslation;

        public Transform(Vector3? scale, Vector3? rotation, Vector3? translation)
        {
            localScale = scale.HasValue ? scale.Value : Vector3.One;
            localRotation = rotation.HasValue ? rotation.Value : Vector3.Zero;
            localTranslation = translation.HasValue ? translation.Value : Vector3.Zero;
        }

        //TODO - clone etc
    }
}