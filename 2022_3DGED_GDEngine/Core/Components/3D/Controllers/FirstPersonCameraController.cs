using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace GD.Engine
{
    public class FirstPersonCameraController : Component
    {
        private float moveSpeed;
        private float strafeSpeed;
        private KeyboardState kbState;

        public FirstPersonCameraController(float moveSpeed, float strafeSpeed)
        {
            this.moveSpeed = moveSpeed;
            this.strafeSpeed = strafeSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            HandleKeyboardInput(gameTime);

            base.Update(gameTime);
        }

        private void HandleKeyboardInput(GameTime gameTime)
        {
            //we have to get state new each update
            kbState = Keyboard.GetState();

            var strafeIncrement = gameTime.ElapsedGameTime.Milliseconds * strafeSpeed;

            if (kbState.IsKeyDown(Keys.A))
                transform.Translate(new Vector3(-strafeIncrement, 0, 0));
            else if (kbState.IsKeyDown(Keys.D))
                transform.Translate(new Vector3(strafeIncrement, 0, 0));

            var moveIncrement = gameTime.ElapsedGameTime.Milliseconds * moveSpeed;

            if (kbState.IsKeyDown(Keys.W))
                transform.Translate(new Vector3(0, 0, -moveIncrement));
            else if (kbState.IsKeyDown(Keys.S))
                transform.Translate(new Vector3(0, 0, moveIncrement));
        }
    }
}