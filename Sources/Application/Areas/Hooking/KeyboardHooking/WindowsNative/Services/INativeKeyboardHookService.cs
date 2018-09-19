using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services
{
    internal interface INativeKeyboardHookService
    {
        void Hook(Action<NativeKeyboardInput> onKeyboardInput);
    }
}