using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models
{
    internal class NativeMouseInput : INativeInput
    {
        public NativeMouseInputDirection Direction { get; }
        public NativeMouseInputKey Key { get; }

        public NativeMouseInput(NativeMouseInputKey key, NativeMouseInputDirection direction)
        {
            Key = key;
            Direction = direction;
        }
    }
}