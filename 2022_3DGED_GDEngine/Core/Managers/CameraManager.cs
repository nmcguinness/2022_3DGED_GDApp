using Microsoft.Xna.Framework;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GD.Engine
{
    /// <summary>
    /// Stores and updates all active cameras
    /// </summary>
    public class CameraManager
    {
        private Camera activeCamera = null;
        private GameObject activeGameObject;
        private Dictionary<string, GameObject> cameras;

        public Camera ActiveCamera
        {
            get
            {
                if (activeCamera == null)
                    throw new NullReferenceException("ActiveCamera not set! Call SetActiveCamera()");

                return activeCamera;
            }
        }

        public CameraManager()
        {
            cameras = new Dictionary<string, GameObject>();
        }

        public bool Add(string id, GameObject camera)
        {
            id = id.Trim().ToLower();

            if (cameras.ContainsKey(id))
                return false;

            cameras.Add(id, camera);
            return true;
        }

        public Camera SetActiveCamera(string id)
        {
            GameObject cameraGameObject = null;

            id = id.Trim().ToLower();

            if (cameras.ContainsKey(id))
                cameraGameObject = cameras[id];

            if (cameraGameObject != null)
            {
                activeCamera = cameraGameObject.GetComponent<Camera>();
                activeGameObject = cameraGameObject;
            }

            return activeCamera;
        }

        public virtual void Update(GameTime gameTime)
        {
            activeGameObject.Update(gameTime);
        }
    }
}