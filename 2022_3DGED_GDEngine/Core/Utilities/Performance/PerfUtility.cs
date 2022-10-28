using GD.Engine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine.Utilities
{
    public class PerfUtility : DrawableGameComponent
    {
        #region Statics

        private static readonly int MAX_TIME_BETWEEN_FPS_UPDATES_IN_MS = 500;

        #endregion Statics

        #region Fields

        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private Vector2 fpsTextStartPosition;
        private Color fpsTextColor;

        private float totalTimeSinceLastFPSUpdate;
        private int fpsCountToShow;
        private int fpsCountSinceLastRefresh;

        #endregion Fields

        #region Constructors

        public PerfUtility(Game game,
        SpriteBatch spriteBatch, SpriteFont spriteFont,
        Vector2 fpsTextStartPosition, Color fpsTextColor)
        : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;

            this.fpsTextStartPosition = fpsTextStartPosition;
            this.fpsTextColor = fpsTextColor;
        }

        #endregion Constructors

        #region Update & Draw

        public override void Update(GameTime gameTime)
        {
            //accumulate time until next text update
            totalTimeSinceLastFPSUpdate += gameTime.ElapsedGameTime.Milliseconds;

            //count the frames
            fpsCountSinceLastRefresh++;

            //every 500ms send the 2x frame count to fpsCountToShow
            if (totalTimeSinceLastFPSUpdate >= MAX_TIME_BETWEEN_FPS_UPDATES_IN_MS)
            {
                //reset time until next count update
                totalTimeSinceLastFPSUpdate = 0;

                //store value to show in Draw()
                fpsCountToShow = 2 * fpsCountSinceLastRefresh;

                //reset frame count
                fpsCountSinceLastRefresh = 0;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null);
            spriteBatch.DrawString(spriteFont, $"FPS [{fpsCountToShow}]", fpsTextStartPosition, fpsTextColor);

            //name
            spriteBatch.DrawString(spriteFont, $"Name:{Application.CameraManager.ActiveCameraName}", fpsTextStartPosition + new Vector2(0, 20), Color.Yellow);

            //position
            var camPos = Application.CameraManager.ActiveCamera.transform.translation;
            camPos.Round(1);
            spriteBatch.DrawString(spriteFont, $"Pos:{camPos}", fpsTextStartPosition + new Vector2(0, 40), Color.Yellow);

            //rotation
            var camRot = Application.CameraManager.ActiveCamera.transform.rotation;
            camRot.Round(1);
            spriteBatch.DrawString(spriteFont, $"Rot:{camRot}", fpsTextStartPosition + new Vector2(0, 60), Color.Yellow);

            //TODO - add more here
            spriteBatch.End();
        }

        #endregion Update & Draw
    }
}