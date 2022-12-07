using GD.Engine.Events;
using GD.Engine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace GD.Engine
{
    public class Render2DManager : PausableDrawableGameComponent
    {
        #region Fields

        private SpriteBatch spriteBatch;
        private UserInterfaceManager userInterfaceManager;
        private SamplerState samplerState;

        #endregion Fields

        #region Constructors

        public Render2DManager(Game game, SpriteBatch spriteBatch, UserInterfaceManager userInterfaceManager)
     : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.userInterfaceManager = userInterfaceManager;

            //used when drawing textures
            this.samplerState = new SamplerState();
            this.samplerState.Filter = TextureFilter.Linear;
        }

        #endregion Constructors

        #region Actions - Events

        protected override void HandleEvent(EventData eventData)
        {
            if (eventData.EventCategoryType == EventCategoryType.Menu)
            {
                if (eventData.EventActionType == EventActionType.OnPlay)
                    StatusType = StatusType.Off;
                else if (eventData.EventActionType == EventActionType.OnPause)
                    StatusType = StatusType.Updated | StatusType.Drawn;
            }
        }

        #endregion Actions - Events

        #region Actions - Draw

        public override void Draw(GameTime gameTime)
        {
            if (IsDrawn)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied, samplerState, null, null, null, null);
                foreach (GameObject gameObject in userInterfaceManager.ActiveScene.ObjectList)
                {
                    List<Renderer2D> renderers = gameObject.GetComponents<Renderer2D>();
                    foreach (Renderer2D renderer in renderers)
                        renderer.Draw(spriteBatch);
                }
                spriteBatch.End();
            }
        }

        #endregion Actions - Draw
    }
}