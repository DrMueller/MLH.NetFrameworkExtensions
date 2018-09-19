namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models
{
    public class LockOptions
    {
        public bool IsCapsLockActive { get; }
        public bool IsNumLockActive { get; }
        public bool IsScrollLockActive { get; }

        public LockOptions(
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