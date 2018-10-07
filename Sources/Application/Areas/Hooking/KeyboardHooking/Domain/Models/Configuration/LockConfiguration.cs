using Mmu.Mlh.LanguageExtensions.Areas.Types.Options;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configuration
{
    public class LockConfiguration
    {
        public Option<bool> CapsLockMustBeActive { get; }
        public Option<bool> NumLockMustBeActive { get; }
        public Option<bool> ScollLockMustBeActive { get; }

        public LockConfiguration(Option<bool> scollLockMustBeActive, Option<bool> numLockMustBeActive, Option<bool> capsLockMustBeActive)
        {
            ScollLockMustBeActive = scollLockMustBeActive;
            NumLockMustBeActive = numLockMustBeActive;
            CapsLockMustBeActive = capsLockMustBeActive;
        }

        internal bool CheckIfApplicable(KeyboardInputLocks inputLocks)
        {
            return ScollLockMustBeActive == inputLocks.IsScrollLockActive &&
                NumLockMustBeActive == inputLocks.IsNumLockActive &&
                CapsLockMustBeActive == inputLocks.IsCapsLockActive;
        }

        public static LockConfiguration CreateNotApplicable()
        {
            return new LockConfiguration(
                Option.CreateNotApplicable<bool>(true),
                Option.CreateNotApplicable<bool>(true),
                Option.CreateNotApplicable<bool>(true));
        }
    }
}