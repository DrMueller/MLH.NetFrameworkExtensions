using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models
{
    public class MouseInput : IInput
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