using System.Text;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs
{
    public class KeyboardInput : IInput
    {
        public KeyboardInputDirection Direction { get; }
        public KeyboardInputKey InputKey { get; }
        public KeyboardInputLocks Locks { get; }
        public KeyboardInputModifiers Modifiers { get; }

        public KeyboardInput(
            KeyboardInputKey inputKey,
            KeyboardInputDirection direction,
            KeyboardInputLocks locks,
            KeyboardInputModifiers modifiers)
        {
            InputKey = inputKey;
            Direction = direction;
            Locks = locks;
            Modifiers = modifiers;
        }

        public string CreateOverview()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Key: {InputKey}");
            sb.AppendLine($"Direction: {Direction}");
            sb.AppendLine($"Modifier Shift: {Modifiers.IsShiftPressed}");
            sb.AppendLine($"Modifier Ctrl: {Modifiers.IsCtrlPressed}");
            sb.AppendLine($"Modifier Alt: {Modifiers.IsAltPressed}");
            sb.AppendLine($"Lock Caps: {Locks.IsCapsLockActive}");
            sb.AppendLine($"Lock Num: {Locks.IsNumLockActive}");
            sb.AppendLine($"Lock Scroll: {Locks.IsScrollLockActive}");

            return sb.ToString();
        }
    }
}