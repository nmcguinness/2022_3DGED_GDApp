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

        //private List<GameObject> gameObjects;
        private GameObjectList opaqueList;
        private GameObjectList transparentList;

        public string Name { get => name; set => name = value.Trim(); }

        public Scene(string name)
        {
            Name = name;
            opaqueList = new GameObjectList();
            transparentList = new GameObjectList();
        }

        public void Add(GameObject gameObject)
        {
            if (gameObject.IsOpaque)
                opaqueList.Add(gameObject);
            else
                transparentList.Add(gameObject);
        }

        public GameObject Find(bool isStatic, bool isOpaque,
                                    Predicate<GameObject> predicate)
        {
            GameObject found = null;
            if (isOpaque)
                found = opaqueList.Find(isStatic, predicate);
            else
                found = transparentList.Find(isStatic, predicate);

            return found;
        }

        public bool Remove(bool isStatic, bool isOpaque,
            Predicate<GameObject> predicate)
        {
            //look in opaque and transparent

            //if found, remove in opaque or transparent

            return true;
        }

        //Remove, Clear, Size

        public virtual void Update(GameTime gameTime)
        {
            opaqueList.Update(gameTime);
            transparentList.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, Camera camera)
        {
            opaqueList.Draw(gameTime, camera);
            transparentList.Draw(gameTime, camera);
        }
    }
}

/*
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
            //TODO - add inefficiency with GetComponent
            foreach (GameObject gameObject in gameObjects)
                gameObject.GetComponent<Renderer>().Draw(Application.GraphicsDevice, camera);
        }
    }
}

 */