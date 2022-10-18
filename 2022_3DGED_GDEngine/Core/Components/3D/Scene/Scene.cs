using GD.Globals;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GD.Engine
{
    /// <summary>
    /// Store all the drawn and updateable GameOjects and call Update and Draw
    /// </summary>
    public class Scene
    {
        private string name;
        private List<GameObject> gameObjects;

        public Scene(string name)
        {
            this.name = name.Trim();
            gameObjects = new List<GameObject>();
        }

        public void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public GameObject Find(Predicate<GameObject> predicate)
        {
            return gameObjects.Find(predicate);
        }

        //Remove, Clear, Size

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in gameObjects)
                gameObject.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, Camera camera)
        {
            foreach (GameObject gameObject in gameObjects)
                gameObject.GetComponent<Renderer>().Draw(Application.GraphicsDevice, camera);
        }
    }
}