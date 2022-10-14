using Microsoft.Xna.Framework;

namespace GD.App
{
    public class AppData
    {
        #region Camera - First Person

        public static readonly float FIRST_PERSON_MOVE_SPEED = 0.009f;
        public static readonly float FIRST_PERSON_STRAFE_SPEED = 0.6f * FIRST_PERSON_MOVE_SPEED;
        public static readonly Vector3 FIRST_PERSON_DEFAULT_CAMERA_POSITION = new Vector3(0, 0, 5);

        #endregion Camera - First Person
    }
}