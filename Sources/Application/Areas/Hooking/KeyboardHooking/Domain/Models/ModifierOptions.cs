namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models
{
    public class ModifierOptions
    {
        public bool IsAltPressed { get; }
        public bool IsCtrlPressed { get; }
        public bool IsShiftPressed { get; }

        public ModifierOptions(
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