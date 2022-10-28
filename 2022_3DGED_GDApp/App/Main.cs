#region Pre-compiler directives

#define DEMO
#define SHOW_DEBUG_INFO

#endregion

using GD.Engine;
using GD.Engine.Events;
using GD.Engine.Globals;
using GD.Engine.Inputs;
using GD.Engine.Managers;
using GD.Engine.Parameters;
using GD.Engine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Application = GD.Engine.Globals.Application;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace GD.App
{
    public class Main : Game
    {
        #region Fields

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BasicEffect skyBoxEffect;
        private BasicEffect effect;

        private CameraManager cameraManager;
        private SceneManager sceneManager;
        private SoundManager soundManager;
        private EventDispatcher eventDispatcher;

        #endregion Fields

        #region Constructors

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        #endregion Constructors

        #region Actions - Initialize

        protected override void Initialize()
        {
            //moved spritebatch initialization here because we need it in InitializeDebug() below
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //core engine - common across any game
            InitializeEngine();

            //game specific content
            InitializeLevel("My Amazing Game", AppData.SKYBOX_WORLD_SCALE);

#if SHOW_DEBUG_INFO
            InitializeDebug();
#endif

            base.Initialize();
        }

        #endregion Actions - Initialize

        #region Actions - Level Specific

        protected override void LoadContent()
        {
            //moved spritebatch initialization to Main::Initialize() because we need it in InitializeDebug()
            //_spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        private void InitializeLevel(string title, float worldScale)
        {
            //set game title
            SetTitle(title);

            //load sounds, textures, models etc
            LoadMediaAssets();

            //initialize curves used by cameras
            InitializeCurves();

            //initialize rails used by cameras
            InitializeRails();

            //add scene manager and starting scenes
            InitializeScenes();

            //add drawn stuff
            InitializeDrawnContent(worldScale);
        }

        private void SetTitle(string title)
        {
            Window.Title = title.Trim();
        }

        private void LoadMediaAssets()
        {
            //sounds, models, textures
            LoadSounds();
            LoadTextures();
            LoadModels();
        }

        private void LoadSounds()
        {
            //load and add to dictionary
        }

        private void LoadTextures()
        {
            //load and add to dictionary
        }

        private void LoadModels()
        {
            //load and add to dictionary
        }

        private void InitializeCurves()
        {
            //load and add to dictionary
        }

        private void InitializeRails()
        {
            //load and add to dictionary
        }

        private void InitializeScenes()
        {
            //initialize a scene
            var scene = new Scene("labyrinth");

            //add scene to the scene manager
            sceneManager.Add(scene.ID, scene);

            //don't forget to set active scene
            sceneManager.SetActiveScene("labyrinth");
        }

        private void InitializeEffects()
        {
            //only for skybox with lighting disabled
            skyBoxEffect = new BasicEffect(_graphics.GraphicsDevice);
            skyBoxEffect.TextureEnabled = true;

            //all other drawn objects
            effect = new BasicEffect(_graphics.GraphicsDevice);
            effect.TextureEnabled = true;
            effect.LightingEnabled = true;
            effect.EnableDefaultLighting();
        }

        private void InitializeCameras()
        {
            //camera
            GameObject cameraGameObject = null;

            #region First Person

            //camera 1
            cameraGameObject = new GameObject("first person camera 1");
            cameraGameObject.Transform = new Transform(null, null, AppData.FIRST_PERSON_DEFAULT_CAMERA_POSITION);
            cameraGameObject.AddComponent(new Camera(MathHelper.PiOver2 / 2, (float)_graphics.PreferredBackBufferWidth / _graphics.PreferredBackBufferHeight, 0.1f, 1000));

            //OLD
            //cameraGameObject.AddComponent(new FirstPersonCameraController(AppData.FIRST_PERSON_MOVE_SPEED, AppData.FIRST_PERSON_STRAFE_SPEED));

            //NEW
            cameraGameObject.AddComponent(new FirstPersonController(AppData.FIRST_PERSON_MOVE_SPEED, AppData.FIRST_PERSON_STRAFE_SPEED,
                AppData.PLAYER_ROTATE_SPEED, true));

            cameraManager.Add(cameraGameObject.Name, cameraGameObject);

            #endregion First Person

            #region Security

            //camera 2
            cameraGameObject = new GameObject("security camera 1");

            cameraGameObject.Transform
                = new Transform(null,
                null,
                new Vector3(0, 2, 5));

            //add camera (view, projection)
            cameraGameObject.AddComponent(new Camera(MathHelper.PiOver2 / 2,
                (float)_graphics.PreferredBackBufferWidth / _graphics.PreferredBackBufferHeight, 0.1f, 1000));

            //add rotation
            cameraGameObject.AddComponent(new CycledRotationBehaviour(
                AppData.SECURITY_CAMERA_ROTATION_AXIS,
                AppData.SECURITY_CAMERA_MAX_ANGLE,
                AppData.SECURITY_CAMERA_ANGULAR_SPEED_MUL,
                TurnDirectionType.Right));

            //adds FOV change on mouse scroll
            cameraGameObject.AddComponent(new CameraFOVController(2));

            cameraManager.Add(cameraGameObject.Name, cameraGameObject);

            #endregion Security

            #region Curve

            Curve3D curve3D = new Curve3D(CurveLoopType.Oscillate);
            curve3D.Add(new Vector3(0, 2, 5), 0);
            curve3D.Add(new Vector3(0, 5, 10), 1000);
            curve3D.Add(new Vector3(0, 8, 25), 2500);
            curve3D.Add(new Vector3(0, 5, 35), 4000);

            cameraGameObject = new GameObject("curve camera 1");
            cameraGameObject.Transform =
                new Transform(null, null, null);
            cameraGameObject.AddComponent(new Camera(
                MathHelper.PiOver2 / 2,
                (float)_graphics.PreferredBackBufferWidth / _graphics.PreferredBackBufferHeight, 0.1f, 1000));
            cameraGameObject.AddComponent(
                new CurveBehaviour(curve3D));

            cameraManager.Add(cameraGameObject.Name, cameraGameObject);

            #endregion Curve

            cameraManager.SetActiveCamera("security camera 1");
        }

        private void InitializeDrawnContent(float worldScale)
        {
            //create sky
            InitializeSkyBoxAndGround(worldScale);

            //quad with crate texture
            InitializeDemoQuad();

            //load an FBX and draw
            InitializeDemoModel();
        }

        private void InitializeDemoModel()
        {
            //game object
            var gameObject = new GameObject("my first sphere - wahoo!", ObjectType.Static, RenderType.Opaque);
            gameObject.Transform = new Transform(0.5f * Vector3.One, null, new Vector3(-2, 2, 0));
            var texture = Content.Load<Texture2D>("Assets/Textures/Props/Crates/crate2");
            var model = Content.Load<Model>("Assets/Models/sphere");
            gameObject.AddComponent(new Renderer(new GDBasicEffect(effect),
                new Material(texture, 1),
                new Engine.ModelMesh(_graphics.GraphicsDevice, model)));

            sceneManager.ActiveScene.Add(gameObject);
        }

        private void InitializeDemoQuad()
        {
            //game object
            var gameObject = new GameObject("my first quad",
                ObjectType.Static, RenderType.Opaque);
            gameObject.Transform = new Transform(null, null, new Vector3(0, 2, 1));  //World
            var texture = Content.Load<Texture2D>("Assets/Textures/Props/Crates/crate1");
            gameObject.AddComponent(new Renderer(new GDBasicEffect(effect),
                new Material(texture, 1), new QuadMesh(_graphics.GraphicsDevice)));

            gameObject.AddComponent(new SimpleRotationBehaviour(new Vector3(1, 0, 0), MathHelper.ToRadians(1 / 16.0f)));

            sceneManager.ActiveScene.Add(gameObject);
        }

        private void InitializeSkyBoxAndGround(float worldScale)
        {
            float halfWorldScale = worldScale / 2.0f;

            GameObject quad = null;
            var gdBasicEffect = new GDBasicEffect(skyBoxEffect);
            var quadMesh = new QuadMesh(_graphics.GraphicsDevice);

            //skybox - back face
            quad = new GameObject("skybox back face");
            quad.Transform = new Transform(new Vector3(worldScale, worldScale, 1), null, new Vector3(0, 0, -halfWorldScale));
            var texture = Content.Load<Texture2D>("Assets/Textures/Skybox/back");
            quad.AddComponent(new Renderer(gdBasicEffect, new Material(texture, 1), quadMesh));
            sceneManager.ActiveScene.Add(quad);

            //skybox - left face
            quad = new GameObject("skybox left face");
            quad.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(0, MathHelper.ToRadians(90), 0), new Vector3(-halfWorldScale, 0, 0));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/left");
            quad.AddComponent(new Renderer(gdBasicEffect, new Material(texture, 1), quadMesh));
            sceneManager.ActiveScene.Add(quad);

            //skybox - right face
            quad = new GameObject("skybox right face");
            quad.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(0, MathHelper.ToRadians(-90), 0), new Vector3(halfWorldScale, 0, 0));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/right");
            quad.AddComponent(new Renderer(gdBasicEffect, new Material(texture, 1), quadMesh));
            sceneManager.ActiveScene.Add(quad);

            //skybox - top face
            quad = new GameObject("skybox top face");
            quad.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(MathHelper.ToRadians(90), MathHelper.ToRadians(-90), 0), new Vector3(0, halfWorldScale, 0));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/sky");
            quad.AddComponent(new Renderer(gdBasicEffect, new Material(texture, 1), quadMesh));
            sceneManager.ActiveScene.Add(quad);

            //skybox - front face
            quad = new GameObject("skybox front face");
            quad.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(0, MathHelper.ToRadians(-180), 0), new Vector3(0, 0, halfWorldScale));
            texture = Content.Load<Texture2D>("Assets/Textures/Skybox/front");
            quad.AddComponent(new Renderer(gdBasicEffect, new Material(texture, 1), quadMesh));
            sceneManager.ActiveScene.Add(quad);

            //ground
            quad = new GameObject("ground");
            quad.Transform = new Transform(new Vector3(worldScale, worldScale, 1), new Vector3(MathHelper.ToRadians(-90), 0, 0), new Vector3(0, 0, 0));
            texture = Content.Load<Texture2D>("Assets/Textures/Foliage/Ground/grass1");
            quad.AddComponent(new Renderer(gdBasicEffect, new Material(texture, 1), quadMesh));
            sceneManager.ActiveScene.Add(quad);
        }

        #endregion Actions - Level Specific

        #region Actions - Engine Specific

        private void InitializeEngine()
        {
            //add support for mouse etc
            InitializeInput();

            //set screen resolution and show/hide mouse
            InitializeGraphics(AppData.APP_RESOLUTION, false);

            //add game effects
            InitializeEffects();

            //add camera, scene manager
            InitializeManagers();

            //add dictionaries to store and access content
            InitializeDictionaries();

            //add game cameras
            InitializeCameras();

            //share some core references
            InitializeGlobals();
        }

        private void InitializeGlobals()
        {
            //Globally shared commonly accessed variables
            Application.Main = this;
            Application.GraphicsDevice = _graphics.GraphicsDevice;
            Application.Content = Content;

            //Add access to managers from anywhere in the code
            Application.CameraManager = cameraManager;
            Application.SceneManager = sceneManager;
            Application.SoundManager = soundManager;
        }

        private void InitializeInput()
        {
            //Globally accessible inputs
            Input.Keys = new KeyboardComponent(this);
            Components.Add(Input.Keys);
            Input.Mouse = new MouseComponent(this);
            Components.Add(Input.Mouse);
            Input.Gamepad = new GamepadComponent(this);
            Components.Add(Input.Gamepad);

            //set mouse in centre at startup
            Input.Mouse.Position = new Vector2(_graphics.PreferredBackBufferWidth / 2.0f,
                _graphics.PreferredBackBufferHeight / 2.0f);
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

            //TODO - consider for later
            //  System.Windows.Forms.Application.SetHighDpiMode(System.Windows.Forms.HighDpiMode.PerMonitor);
        }

        private void InitializeManagers()
        {
            //add event dispatcher for system events - the most important element!!!!!!
            //eventDispatcher = new EventDispatcher(this);

            //add support for multiple cameras and camera switching
            cameraManager = new CameraManager();

            //add support for multiple scenes and scene switching
            sceneManager = new SceneManager();

            //add support for playing sounds
            //soundManager = new SoundManager();

            //TODO - add other managers
        }

        private void InitializeDictionaries()
        {
            //TODO - add texture dictionary, soundeffect dictionary, model dictionary
        }

        private void InitializeDebug()
        {
            var perfUtility = new PerfUtility(this,
                _spriteBatch,
                Content.Load<SpriteFont>("Assets/Fonts/Perf"),
                new Vector2(10, 10),
                Color.Yellow);

            Components.Add(perfUtility);
        }

        #endregion Actions - Engine Specific

        #region Actions - Update, Draw

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //update all drawn game objects in the active scene
            sceneManager.Update(gameTime);

            //update active camera
            cameraManager.Update(gameTime);

#if DEMO

            #region Demo - Camera switching

            if (Input.Keys.IsPressed(Keys.F1))
                cameraManager.SetActiveCamera("first person camera 1");
            else if (Input.Keys.IsPressed(Keys.F2))
                cameraManager.SetActiveCamera("security camera 1");
            else if (Input.Keys.IsPressed(Keys.F3))
                cameraManager.SetActiveCamera("curve camera 1");

            #endregion Demo - Camera switching

            #region Demo - Gamepad

            var thumbsL = Input.Gamepad.ThumbSticks(false);
            //   System.Diagnostics.Debug.WriteLine(thumbsL);

            var thumbsR = Input.Gamepad.ThumbSticks(false);
            //     System.Diagnostics.Debug.WriteLine(thumbsR);

            //    System.Diagnostics.Debug.WriteLine($"A: {Input.Gamepad.IsPressed(Buttons.A)}");

            #endregion Demo - Gamepad

#endif
            //fixed a bug with components not getting Update called
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //get active scene, get camera, and call the draw on the active scene
            sceneManager.ActiveScene.Draw(gameTime, cameraManager.ActiveCamera);

            base.Draw(gameTime);
        }

        #endregion Actions - Update, Draw
    }
}