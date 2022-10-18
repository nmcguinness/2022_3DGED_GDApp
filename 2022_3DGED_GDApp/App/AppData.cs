using Microsoft.Xna.Framework;

namespace GD.App
{
    public class AppData
    {
        public static readonly Vector2 APP_RESOLUTION = new Vector2(640, 480);

        public static readonly float SKYBOX_WORLD_SCALE = 20;

        #region Camera - First Person

        public static readonly float FIRST_PERSON_MOVE_SPEED = 0.009f;
        public static readonly float FIRST_PERSON_STRAFE_SPEED = 0.6f * FIRST_PERSON_MOVE_SPEED;
        public static readonly Vector3 FIRST_PERSON_DEFAULT_CAMERA_POSITION = new Vector3(0, 2, 5);

        #endregion Camera - First Person
    }
}