using Microsoft.Xna.Framework;
using System;

namespace GD.Engine
{
    public class ThirdPersonController : Component
    {
        private GameObject target;

        public ThirdPersonController(GameObject target)
        {
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {
            if (target != null)
            {
                //use target position + offset to generate new camera position
                var newPosition = target.Transform.translation
                    + new Vector3(0, 1, 5);

                //set new camera position
                transform.SetTranslation(newPosition);
            }
            else
                throw new ArgumentNullException("Target not set! Do this in main");

            //since parent Update does nothing then dont bother calling it
            //base.Update(gameTime);
        }
    }
}