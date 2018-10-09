using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Imports;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardInputLocksFactory : IKeyboardInputLocksFactory
    {
        public KeyboardInputLocks Create()
        {
            var isCapsLockActive = Convert.ToBoolean(NativeMethods.GetKeyState(Keys.CapsLock)) & true;
            var isNumLockActive = Convert.ToBoolean(NativeMethods.GetKeyState(Keys.NumLock)) & true;
            var isScrolLLockActivate = Convert.ToBoolean(NativeMethods.GetKeyState(Keys.Scroll)) & true;

            return new KeyboardInputLocks(
                isScrolLLockActivate,
                isNumLockActive,
                isCapsLockActive);
        }
    }
}