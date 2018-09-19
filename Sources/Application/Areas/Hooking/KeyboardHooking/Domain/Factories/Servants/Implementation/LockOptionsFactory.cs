﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Imports;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class LockOptionsFactory : ILockOptionsFactory
    {
        public LockOptions Create()
        {
            var isCapsLockActive = Convert.ToBoolean(DllImports.GetKeyState(Keys.CapsLock)) & true;
            var isNumLockActive = Convert.ToBoolean(DllImports.GetKeyState(Keys.NumLock)) & true;
            var isScrolLLockActivate = Convert.ToBoolean(DllImports.GetKeyState(Keys.Scroll)) & true;

            return new LockOptions(
                isScrolLLockActivate,
                isNumLockActive,
                isCapsLockActive);
        }
    }
}