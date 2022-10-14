using Microsoft.Xna.Framework;

namespace GD.Engine
{
    public class RotationBehaviour : Component
    {
        private Vector3 rotationAxis = Vector3.UnitY;
        private float rotationSpeedInRadians;

        public RotationBehaviour(Vector3 rotationAxis, float rotationSpeedInRadians)
        {
            this.rotationAxis = rotationAxis;
            this.rotationSpeedInRadians = rotationSpeedInRadians;
        }

        public override void Update(GameTime gameTime)
        {
            //stuff
            //transform.rotation = transform.rotation + new Vector3(0, MathHelper.ToRadians(1), 0);

            transform.rotation = transform.rotation + gameTime.ElapsedGameTime.Milliseconds * rotationSpeedInRadians * rotationAxis;

            //dont call parent since its Update does nothing
            //base.Update(gameTime);
        }
    }
}