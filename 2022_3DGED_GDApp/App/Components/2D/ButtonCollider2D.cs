using GD.Engine;
using GD.Engine.Events;
using GD.Engine.Inputs;

namespace GD.App
{
    public class ButtonCollider2D : Collider2D
    {
        private EventData eventData;

        public ButtonCollider2D(GameObject gameObject, SpriteRenderer spriteRenderer,
            EventData eventData) : base(gameObject, spriteRenderer)
        {
            this.eventData = eventData;
        }

        public override void HandleMouseClick(MouseButton mouseButton)
        {
            EventDispatcher.Raise(eventData);
        }
    }
}