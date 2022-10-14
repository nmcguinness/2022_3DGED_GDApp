using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace GD.Engine
{
    public class FirstPersonCameraController : Component
    {
        private float moveSpeed;
        private KeyboardState kbState;

        public FirstPersonCameraController(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
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

            var moveIncrement = gameTime.ElapsedGameTime.Milliseconds * moveSpeed;

            //if A then move Left
            if (kbState.IsKeyDown(Keys.A))
            {
                transform.Translate(new Vector3(-moveIncrement, 0, 0));  //-ve axis
                //transform.translation = transform.translation + new Vector3(-moveIncrement, 0, 0);  //-ve axis
            }
            //else if D then move Right
            else if (kbState.IsKeyDown(Keys.D))
            {
                transform.Translate(new Vector3(moveIncrement, 0, 0)); //+ve axis
                // transform.translation = transform.translation + new Vector3(moveIncrement, 0, 0); //+ve axis
            }
        }
    }
}