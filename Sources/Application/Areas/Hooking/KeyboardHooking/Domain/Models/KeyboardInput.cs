using System.Text;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models
{
    public class KeyboardInput : IInput
    {
        public KeyboardInputDirection Direction { get; }
        public KeyboardInputKey InputKey { get; }
        public KeyboardInputLocks InputLocks { get; }
        public KeyboardInputModifiers InputModifiers { get; }

        public KeyboardInput(
            KeyboardInputKey inputKey,
            KeyboardInputDirection direction,
            KeyboardInputLocks inputLocks,
            KeyboardInputModifiers inputModifiers)
        {
            InputKey = inputKey;
            Direction = direction;
            InputLocks = inputLocks;
            InputModifiers = inputModifiers;
        }

        public string CreateOverview()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Key: {InputKey}");
            sb.AppendLine($"Direction: {Direction}");
            sb.AppendLine($"Modifier Shift: {InputModifiers.IsShiftPressed}");
            sb.AppendLine($"Modifier Ctrl: {InputModifiers.IsCtrlPressed}");
            sb.AppendLine($"Modifier Alt: {InputModifiers.IsAltPressed}");
            sb.AppendLine($"Lock Caps: {InputLocks.IsCapsLockActive}");
            sb.AppendLine($"Lock Num: {InputLocks.IsNumLockActive}");
            sb.AppendLine($"Lock Scroll: {InputLocks.IsScrollLockActive}");

            return sb.ToString();
        }
    }
}