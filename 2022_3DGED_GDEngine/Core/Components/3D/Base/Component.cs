using System.Collections.Generic;

namespace GD.Engine
{
    /// <summary>
    /// A part of a game object e.g. Mesh, MeshRenderer, Camera, FirstPersonController
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// Friendly name for the current component
        /// </summary>
        public string name;

        /// <summary>
        /// Parent GameObject for the component
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// Transform of the parent GameObject for the component
        /// </summary>
        public Transform transform;
    }
}