using GD.Globals;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GD.Engine
{
    /// <summary>
    /// Stores all static and dynamic game objects
    /// There will be two in the scene (opaque, transparent)
    /// </summary>
    public class GameObjectList
    {
        /// <summary>
        /// Stores any object which persists during game
        /// </summary>
        private List<GameObject> staticList;

        /// <summary>
        /// Stores any object which can be added/removed (e.g. pickup)
        /// </summary>
        private List<GameObject> dynamicList;

        public List<GameObject> StaticList
        { get { return staticList; } }

        public List<GameObject> DynamicList
        { get { return staticList; } }

        public GameObjectList()
        {
            staticList = new List<GameObject>();
            dynamicList = new List<GameObject>();
        }

        public void Add(GameObject gameObject)
        {
            if (gameObject.IsStatic)
                staticList.Add(gameObject);
            else
                dynamicList.Add(gameObject);
        }

        public GameObject Find(bool isStatic, Predicate<GameObject> predicate)
        {
            GameObject found = null;
            if (isStatic)
                found = staticList.Find(predicate);
            else
                found = dynamicList.Find(predicate);

            return found;
        }

        public bool Remove(bool isStatic, Predicate<GameObject> predicate)
        {
            GameObject found = Find(isStatic, predicate);
            if (found == null)
                return false;

            if (isStatic)
                staticList.Remove(found);
            else
                dynamicList.Remove(found);

            return true;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in staticList)
                gameObject.Update(gameTime);

            foreach (GameObject gameObject in dynamicList)
                gameObject.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, Camera camera)
        {
            //TODO - add inefficiency with GetComponent
            foreach (GameObject gameObject in staticList)
                gameObject.GetComponent<Renderer>().Draw(Application.GraphicsDevice, camera);

            foreach (GameObject gameObject in staticList)
                gameObject.GetComponent<Renderer>().Draw(Application.GraphicsDevice, camera);
        }

        //TODO - Clear, FindAll, RemoveAll, Size
    }
}