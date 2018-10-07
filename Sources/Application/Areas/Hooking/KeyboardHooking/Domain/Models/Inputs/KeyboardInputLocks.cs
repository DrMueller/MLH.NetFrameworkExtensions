namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs
{
    public class KeyboardInputLocks
    {
        public bool IsCapsLockActive { get; }
        public bool IsNumLockActive { get; }
        public bool IsScrollLockActive { get; }

        public KeyboardInputLocks(
            bool isScrollLockActive,
            bool isNumLockActive,
            bool isCapsLockActive)
        {
            IsScrollLockActive = isScrollLockActive;
            IsNumLockActive = isNumLockActive;
            IsCapsLockActive = isCapsLockActive;
        }
    }
}