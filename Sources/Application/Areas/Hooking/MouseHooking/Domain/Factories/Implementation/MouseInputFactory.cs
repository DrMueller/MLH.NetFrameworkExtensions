using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories.Implementation
{
    public class MouseInputFactory : IMouseInputFactory
    {
        public MouseInput CreateFromNativeMouseInput(NativeMouseInput nativeMouseInput)
        {
            return new MouseInput(
                MapKey(nativeMouseInput.Key),
                MapDirection(nativeMouseInput.Direction));
        }

        private static MouseInputDirection MapDirection(NativeMouseInputDirection nativeDirection)
        {
            switch (nativeDirection)
            {
                case NativeMouseInputDirection.MouseDown:
                {
                    return MouseInputDirection.MouseDown;
                }

                default:

                {
                    return MouseInputDirection.MouseUp;
                }
            }
        }

        private static MouseInputKey MapKey(NativeMouseInputKey nativeKey)
        {
            switch (nativeKey)
            {
                case NativeMouseInputKey.Left:
                {
                    return MouseInputKey.Left;
                }
                default:
                {
                    return MouseInputKey.Right;
                }
            }
        }
    }
}