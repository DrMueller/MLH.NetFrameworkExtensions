using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class MouseInputFactory : IMouseInputFactory
    {
        public MouseInput Create(NativeMouseInput nativeInput)
        {
            return new MouseInput(
                MapKey(nativeInput.Key),
                MapDirection(nativeInput.Direction));
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