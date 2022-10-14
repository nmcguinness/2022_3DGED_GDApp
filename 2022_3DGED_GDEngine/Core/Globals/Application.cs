﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GD.Globals
{
    /// <summary>
    /// Static class that contains global objects used in the engine.
    /// </summary>
    public class Application  //TODO - : IDisposable
    {
        /// <summary>
        /// Gets or sets the main game
        /// </summary>
        public static Game Main { get; set; }

        /// <summary>
        /// Gets or sets the content manager.
        /// </summary>
        public static ContentManager Content { get; set; }

        /// <summary>
        /// Gets or sets the graphics device.
        /// </summary>
        public static GraphicsDevice GraphicsDevice { get; set; }

        /// <summary>
        /// Gets or sets the graphics device manager.
        /// </summary>
        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }
    }
}