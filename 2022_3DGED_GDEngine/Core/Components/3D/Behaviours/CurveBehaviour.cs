using GD.Engine;
using GD.Engine.Parameters;
using Microsoft.Xna.Framework;

namespace GD.App
{
    public class CurveBehaviour : Component
    {
        private Curve3D curve3D;

        public CurveBehaviour(Curve3D curve3D)
        {
            this.curve3D = curve3D;
        }

        public override void Update(GameTime gameTime)
        {
            double time = gameTime.TotalGameTime.TotalMilliseconds;

            Vector3 newTranslation = curve3D.Evaluate(time, 4);

            transform.SetTranslation(newTranslation);

            base.Update(gameTime);
        }
    }
}