using GD.Engine.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace GD.Engine
{
    public class ForwardSceneRenderer : SceneRenderer
    {
        public ForwardSceneRenderer(GraphicsDevice graphiceDevice)
        {
            base.Initialize(graphiceDevice);
        }

        public override void Draw(GraphicsDevice graphicsDevice, Camera camera, Scene scene)
        {
            //set viewport for the active camera (e.g. split screen)
            graphicsDevice.Viewport = camera.ViewPort;

            //sort by alpha
            //   scene.Renderers.Sort((x, y) => y.Material.Alpha.CompareTo(x.Material.Alpha));

            //set opaque
            SetGraphicsStates(true);

            //draw static opaque game objects
            foreach (Renderer renderer in scene.OpaqueList.StaticList.Renderers)
                renderer.Draw(graphicsDevice, camera);

            //draw dynamic opaque game objects
            foreach (Renderer renderer in scene.OpaqueList.DynamicList.Renderers)
                renderer.Draw(graphicsDevice, camera);

            //set opaque
            SetGraphicsStates(false);

            //draw static transparent game objects
            foreach (Renderer renderer in scene.TransparentList.StaticList.Renderers)
                renderer.Draw(graphicsDevice, camera);

            //draw dynamic opaque game objects
            foreach (Renderer renderer in scene.TransparentList.DynamicList.Renderers)
                renderer.Draw(graphicsDevice, camera);
        }
    }
}