using System;
using System.Collections.Generic;
using System.Text;

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

        public List<GameObject> StaticList { get { return staticList; } }
        public List<GameObject> DynamicList { get { return staticList; } }

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

        //TODO - Clear, FindAll, RemoveAll, Size
    }
}