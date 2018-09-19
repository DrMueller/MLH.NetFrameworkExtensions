namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models
{
    public class MouseInput
    {
        public MouseInputDirection Direction { get; }
        public MouseInputKey InputKey { get; }

        public MouseInput(MouseInputKey inputKey, MouseInputDirection direction)
        {
            InputKey = inputKey;
            Direction = direction;
        }
    }
}