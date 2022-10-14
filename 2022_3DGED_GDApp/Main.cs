using GD.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GD.App
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BasicEffect effect;
        private GameObject cameraGameObject;
        private GameObject firstQuadGameObject;
        private GameObject secondQuadGameObject;

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
            effect.TextureEnabled = true;

            //camera
            cameraGameObject = new GameObject("static camera");
            cameraGameObject.Transform = new Transform(null, null, new Vector3(0, 0, 5));
            cameraGameObject.AddComponent(new Camera(MathHelper.PiOver2 / 2, (float)_graphics.PreferredBackBufferWidth / _graphics.PreferredBackBufferHeight, 0.1f, 1000));

            //game object
            firstQuadGameObject = new GameObject("my first quad");
            firstQuadGameObject.Transform = new Transform(null, null, new Vector3(0, 0, 0));  //World
            var texture = Content.Load<Texture2D>("Assets/Textures/Props/Crates/crate1");
            firstQuadGameObject.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));
            firstQuadGameObject.AddComponent(new RotationBehaviour(new Vector3(0, 1, 0), MathHelper.ToRadians(1 / 16.0f)));
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
            firstQuadGameObject.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your draw logic here
            var renderer = firstQuadGameObject.GetComponent<Renderer>();
            var camera = cameraGameObject.GetComponent<Camera>();
            renderer.Draw(_graphics.GraphicsDevice, camera);

            base.Draw(gameTime);
        }
    }
}