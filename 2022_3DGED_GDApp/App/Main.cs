using GD.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GD.App
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BasicEffect effect;

        private GameObject cameraGameObject;
        private GameObject firstQuadGameObject;
        private GameObject skyBoxBackFaceGO;
        private GameObject skyBoxLeftFaceGO;
        private GameObject skyBoxRightFaceGO;
        public GameObject skyBoxTopFaceGO;
        private GameObject skyBoxFrontFaceGO;
        private GameObject groundGO;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //set screen resolution and show/hide mouse
            InitializeGraphics(AppData.APP_RESOLUTION, false);

            //add game effects
            InitializeEffects();

            //add game cameras
            InitializeCameras();

            //create sky
            InitializeSkyBoxAndGround(AppData.SKYBOX_WORLD_SCALE);

            //quad with crate texture
            InitializeDemoQuad();

            base.Initialize();
        }

        private void InitializeEffects()
        {
            //effect
            effect = new BasicEffect(_graphics.GraphicsDevice);
            effect.TextureEnabled = true;
            //effect.LightingEnabled = true;
            //effect.EnableDefaultLighting();
        }

        private void InitializeCameras()
        {
            //camera
            cameraGameObject = new GameObject("static camera");
            cameraGameObject.Transform = new Transform(null, null, AppData.FIRST_PERSON_DEFAULT_CAMERA_POSITION);
            cameraGameObject.AddComponent(new Camera(MathHelper.PiOver2 / 2, (float)_graphics.PreferredBackBufferWidth / _graphics.PreferredBackBufferHeight, 0.1f, 1000));
            cameraGameObject.AddComponent(new FirstPersonCameraController(AppData.FIRST_PERSON_MOVE_SPEED, AppData.FIRST_PERSON_STRAFE_SPEED));
        }

        private void InitializeDemoQuad()
        {
            //game object
            firstQuadGameObject = new GameObject("my first quad");
            firstQuadGameObject.Transform = new Transform(null, null, new Vector3(0, 2, 1));  //World
            var texture = Content.Load<Texture2D>("Assets/Textures/Props/Crates/crate1");
            firstQuadGameObject.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));
            firstQuadGameObject.AddComponent(new RotationBehaviour(new Vector3(1, 0, 0), MathHelper.ToRadians(1 / 16.0f)));
        }

        private void InitializeSkyBoxAndGround(float worldScale)
        {
            float halfWorldScale = worldScale / 2.0f;

            //skybox - back face
            skyBoxBackFaceGO = new GameObject("skybox back face");
            skyBoxBackFaceGO.Transform = new Transform(new Vector3(worldScale, worldScale, 1), null, new Vector3(0, 0, -halfWorldScale));
            var texture = Content.Load<Texture2D>("Assets/Textures/Skybox/back");
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

            //skybox - top face
            skyBoxTopFaceGO = new GameObject("skybox top face");
            skyBoxTopFaceGO.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(MathHelper.ToRadians(90), MathHelper.ToRadians(-90), 0), new Vector3(0, halfWorldScale, 0));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/sky");
            skyBoxTopFaceGO.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));

            //skybox - front face
            skyBoxFrontFaceGO = new GameObject("skybox front face");
            skyBoxFrontFaceGO.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(0, MathHelper.ToRadians(-180), 0), new Vector3(0, 0, halfWorldScale));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/front");
            skyBoxFrontFaceGO.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));

            //ground
            groundGO = new GameObject("ground");
            groundGO.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(MathHelper.ToRadians(-90), 0, 0), new Vector3(0, 0, 0));
            texture = Content.Load<Texture2D>("Assets/Textures/Foliage/Ground/grass1");
            groundGO.AddComponent(new Renderer(new GDBasicEffect(effect), new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));
        }

        /// <summary>
        /// Sets game window dimensions and shows/hides the mouse
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="isMouseVisible"></param>
        private void InitializeGraphics(
           Vector2 resolution, bool isMouseVisible)
        {
            //calling set property
            _graphics.PreferredBackBufferWidth = (int)resolution.X;
            _graphics.PreferredBackBufferHeight = (int)resolution.Y;
            IsMouseVisible = isMouseVisible;
            _graphics.ApplyChanges();

            //fix the line issue at boundary between skybox textures
            SamplerState samplerState = new SamplerState();
            samplerState.AddressU = TextureAddressMode.Mirror;
            samplerState.AddressV = TextureAddressMode.Mirror;
            _graphics.GraphicsDevice.SamplerStates[0] = samplerState;
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
            skyBoxTopFaceGO.GetComponent<Renderer>().Draw(_graphics.GraphicsDevice, camera);
            skyBoxFrontFaceGO.GetComponent<Renderer>().Draw(_graphics.GraphicsDevice, camera);

            //draw ground
            groundGO.GetComponent<Renderer>().Draw(_graphics.GraphicsDevice, camera);

            base.Draw(gameTime);
        }
    }
}