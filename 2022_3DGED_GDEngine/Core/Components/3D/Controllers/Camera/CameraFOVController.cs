﻿using GD.Engine.Globals;
using Microsoft.Xna.Framework;

namespace GD.Engine
{
    public class CameraFOVController : Component
    {
        private float scrollWheelMultiplier;
        private Camera camera;

        public CameraFOVController(float scrollWheelMultiplier)
        {
            //let's use ternary operator to validate the input
            this.scrollWheelMultiplier
                = (scrollWheelMultiplier == 0) ? 1 : scrollWheelMultiplier;

            camera = gameObject.GetComponent<Camera>();
        }

        public override void Update(GameTime gameTime)
        {
            //listen for mouse scroll wheel
            int delta = Input.Mouse.GetDeltaFromScrollWheel();

            //if positive, increase camera FOV by scrollWheelMultiplier
            if (delta > 0)
                camera.FieldOfView += MathHelper.ToRadians(scrollWheelMultiplier);
            //if negative, decrease camera FOV by scrollWheelMultiplier
            else if (delta < 0)
                camera.FieldOfView -= MathHelper.ToRadians(scrollWheelMultiplier);

            base.Update(gameTime);
        }
    }
}