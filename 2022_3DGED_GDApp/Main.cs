using GD.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GD.App
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BasicEffect effect;
        private Camera camera;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            SetGraphics(640, 480, false);

            //effect
            effect = new BasicEffect(_graphics.GraphicsDevice);

            //camera
            camera = new Camera(MathHelper.PiOver2 / 2, (float)_graphics.PreferredBackBufferWidth / _graphics.PreferredBackBufferHeight,
                0.1f, 1000);

            //game object
            GameObject firstQuad = new GameObject("my first quad");
            firstQuad.Transform = new Transform(null, null, new Vector3(1, 0, 0));  //World
            firstQuad.AddComponent(new QuadMesh(_graphics.GraphicsDevice));         //Vertices & Indices
                                                                                    //Material - color, texture

            base.Initialize();
        }

        /// <summary>
        /// Sets game window dimensions and shows/hides the mouse
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="isMouseVisible"></param>
        private void SetGraphics(
           int width, int height, bool isMouseVisible)
        {
            //calling set property
            _graphics.PreferredBackBufferWidth = width;
            _graphics.PreferredBackBufferHeight = height;
            IsMouseVisible = isMouseVisible;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}