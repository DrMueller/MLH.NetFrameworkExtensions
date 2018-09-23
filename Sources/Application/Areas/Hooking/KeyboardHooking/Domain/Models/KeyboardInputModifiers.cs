namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models
{
    public class KeyboardInputModifiers
    {
        public bool IsAltPressed { get; }
        public bool IsCtrlPressed { get; }
        public bool IsShiftPressed { get; }

        public KeyboardInputModifiers(
            bool isCtrlPressed,
            bool isAltPressed,
            bool isShiftPressed)
        {
            IsCtrlPressed = isCtrlPressed;
            IsAltPressed = isAltPressed;
            IsShiftPressed = isShiftPressed;
        }
    }
}