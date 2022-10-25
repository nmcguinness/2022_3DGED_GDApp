//#define HI_RES

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GD.App
{
    public class AppData
    {
        #region Graphics

#if HI_RES
        public static readonly Vector2 APP_RESOLUTION = new Vector2(1920, 1080);

#else
        public static readonly Vector2 APP_RESOLUTION = new Vector2(640, 480);
#endif

        #endregion Graphics

        #region World Scale

        public static readonly float SKYBOX_WORLD_SCALE = 100;

        #endregion World Scale

        #region Camera - First Person

        public static readonly float FIRST_PERSON_MOVE_SPEED = 0.009f;
        public static readonly float FIRST_PERSON_STRAFE_SPEED = 0.6f * FIRST_PERSON_MOVE_SPEED;
        public static readonly Vector3 FIRST_PERSON_DEFAULT_CAMERA_POSITION = new Vector3(0, 2, 5);

        #endregion Camera - First Person

        #region Camera - Security Camera

        public static readonly float SECURITY_CAMERA_MAX_ANGLE = 45;
        public static readonly float SECURITY_CAMERA_ANGULAR_SPEED_MUL = 50;

        #endregion Camera - Security Camera

        #region Input Key Mappings

        public static readonly Keys[] KEYS_ONE = { Keys.W, Keys.S, Keys.A, Keys.D };
        public static readonly Keys[] KEYS_TWO = { Keys.U, Keys.J, Keys.H, Keys.K };

        #endregion Input Key Mappings

        #region Movement Constants

        public static readonly float PLAYER_MOVE_SPEED = 0.1f;
        private static readonly float PLAYER_STRAFE_SPEED_MULTIPLIER = 0.75f;
        public static readonly float PLAYER_STRAFE_SPEED = PLAYER_STRAFE_SPEED_MULTIPLIER * PLAYER_MOVE_SPEED;
        public static readonly float PLAYER_ROTATE_SPEED = 0.01f;

        #endregion Movement Constants
    }
}