namespace GD.Engine
{
    /// <summary>
    /// Used to define static (lifetime of game) or dynamic (transient) game objects
    /// </summary>
    /// <see cref="GameObject"/>
    public enum ObjectType : sbyte
    {
        Static = 1,
        Dynamic = 0
    }
    /// <summary>
    /// Used to define if gameobject is opaque or transparent. doh!
    /// </summary>
    /// <see cref="GameObject"/>
    public enum RenderType : sbyte
    {
        Opaque = 1,
        Transparent = 0
    }

    /// <summary>
    /// Possible status types for GameObject within the game (e.g. Update | Drawn, Update, Drawn, Off)
    /// </summary>
    public enum StatusType
    {
        Off = 0,            //turn object off
        Drawn = 1,           //e.g. a game or ui object a renderer but no components
        Updated = 2,         //e.g. a camera
        /*
        * Q. Why do we use powers of 2? Will it allow us to do anything different?
        * A. StatusType.Updated | StatusType.Drawn - See ObjectManager::Update() or Draw()
        */
    }
}