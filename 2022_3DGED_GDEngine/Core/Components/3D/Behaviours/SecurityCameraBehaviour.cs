using Microsoft.Xna.Framework;
using System;

namespace GD.Engine
{
    /// <summary>
    /// Causes the attached camera to rotate at a user defined
    /// speed to a max and min angle in degrees
    /// </summary>
    public class SecurityCameraBehaviour : Component
    {
        private static readonly int ROUND_PRECISION = 4;

        private float maxAngleInDegrees;
        private float angularSpeedMultiplier;
        private TurnDirectionType turnDirectionType;

        public SecurityCameraBehaviour(float maxAngleInDegrees,
            float angularSpeedMultiplier,
            TurnDirectionType turnDirectionType)
        {
            this.maxAngleInDegrees = maxAngleInDegrees;
            this.angularSpeedMultiplier = angularSpeedMultiplier;
            this.turnDirectionType = turnDirectionType;
        }

        public override void Update(GameTime gameTime)
        {
            double t = gameTime.TotalGameTime.TotalSeconds;
            t %= 360;
            double angleInDegrees = maxAngleInDegrees * Math.Round(
                Math.Sin(MathHelper.ToRadians((float)
               ((int)turnDirectionType * angularSpeedMultiplier * t))), ROUND_PRECISION);

            transform.SetRotation(0, MathHelper.ToRadians((float)angleInDegrees), 0);

            base.Update(gameTime);
        }
    }
}