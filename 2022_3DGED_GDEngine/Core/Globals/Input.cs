﻿using GD.Inputs;
using System;

namespace GD.Globals
{
    /// <summary>
    /// Static class that contains input objects used in the engine.
    /// </summary>
    public class Input //TODO - : IDisposable
    {
        /// <summary>
        /// Gets or sets keyboard inputs
        /// </summary>
        public static KeyboardComponent Keys { get; set; }

        /// <summary>
        /// Gets or sets mouse inputs.
        /// </summary>
        public static MouseComponent Mouse { get; set; }

        /// <summary>
        /// Gets or sets gamepad inputs.
        /// </summary>
        public static GamepadComponent Gamepad { get; set; }
    }
}