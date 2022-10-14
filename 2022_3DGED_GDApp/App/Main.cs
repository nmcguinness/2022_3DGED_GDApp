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
        private GameObject skyBoxBackFaceGO;
        private GameObject skyBoxLeftFaceGO;
        private GameObject skyBoxRightFaceGO;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            SetGraphics(1024, 768, false);

            //effect
            effect = new BasicEffect(_graphics.GraphicsDevice);
            effect.TextureEnabled = true;

            //camera
            cameraGameObject = new GameObject("static camera");
            cameraGameObject.Transform = new Transform(null, null, AppData.FIRST_PERSON_DEFAULT_CAMERA_POSITION);
            cameraGameObject.AddComponent(new Camera(MathHelper.PiOver2 / 2, (float)_graphics.PreferredBackBufferWidth / _graphics.PreferredBackBufferHeight, 0.1f, 1000));
            cameraGameObject.AddComponent(new FirstPersonCameraController(AppData.FIRST_PERSON_MOVE_SPEED, AppData.FIRST_PERSON_STRAFE_SPEED));

            //game object
            firstQuadGameObject = new GameObject("my first quad");
            firstQuadGameObject.Transform = new Transform(null, null, new Vector3(0, 0, 1));  //World
            var texture = Content.Load<Texture2D>("Assets/Textures/Props/Crates/crate1");
            firstQuadGameObject.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));
            //firstQuadGameObject.AddComponent(new RotationBehaviour(new Vector3(1, 0, 0), MathHelper.ToRadians(5 / 16.0f)));

            float worldScale = 10;
            float halfWorldScale = worldScale / 2.0f;

            //skybox - back face
            skyBoxBackFaceGO = new GameObject("skybox back face");
            skyBoxBackFaceGO.Transform = new Transform(new Vector3(worldScale, worldScale, 1), null, new Vector3(0, 0, -halfWorldScale));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/back");
            skyBoxBackFaceGO.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));

            //skybox - left face
            skyBoxLeftFaceGO = new GameObject("skybox left face");
            skyBoxLeftFaceGO.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(0, MathHelper.ToRadians(90), 0), new Vector3(-halfWorldScale, 0, 0));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/left");
            skyBoxLeftFaceGO.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));

            //skybox - right face
            skyBoxRightFaceGO = new GameObject("skybox right face");
            skyBoxRightFaceGO.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(0, MathHelper.ToRadians(-90), 0), new Vector3(halfWorldScale, 0, 0));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/right");
            skyBoxRightFaceGO.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));

            //top face

            //front face

            //grass plane

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

            //in order for us to call update on FirstPersonCameraController
            cameraGameObject.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //get camera
            var camera = cameraGameObject.GetComponent<Camera>();

            //draw quad
            firstQuadGameObject.GetComponent<Renderer>().Draw(_graphics.GraphicsDevice, camera);

            //draw skybox
            skyBoxBackFaceGO.GetComponent<Renderer>().Draw(_graphics.GraphicsDevice, camera);
            skyBoxLeftFaceGO.GetComponent<Renderer>().Draw(_graphics.GraphicsDevice, camera);
            skyBoxRightFaceGO.GetComponent<Renderer>().Draw(_graphics.GraphicsDevice, camera);

            base.Draw(gameTime);
        }
    }
}