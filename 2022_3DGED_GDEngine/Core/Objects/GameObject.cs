using System.Collections.Generic;

namespace GD.Engine
{
    /// <summary>
    /// Base object in the game
    /// </summary>
    public class GameObject
    {
        #region Fields

        /// <summary>
        /// Friendly name for the current object
        /// </summary>
        protected string name;

        /// <summary>
        /// Stores S, R, T of GameObject to generate the world matrix
        /// </summary>
        protected Transform transform;

        /// <summary>
        /// List of all attached components
        /// </summary>
        protected List<Component> components;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets/sets the game object name
        /// </summary>
        public string Name { get => name; set => name = value.Trim(); }

        /// <summary>
        /// Gets/sets the transform associated with the current game object
        /// </summary>
        public Transform Transform { get => transform; set => transform = value; }

        /// <summary>
        /// Gets a list of all components (e.g. controllers, behaviours, camera) of the current object
        /// </summary>
        public List<Component> Components { get => components; }

        #endregion Properties

        #region Constructors

        public GameObject(string name)
        {
            Name = name;
        }

        #endregion Constructors

        //TODO - AddComponent, RemoveComponent
    }
}