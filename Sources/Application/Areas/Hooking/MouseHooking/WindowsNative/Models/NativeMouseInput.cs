namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models
{
    public class NativeMouseInput
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