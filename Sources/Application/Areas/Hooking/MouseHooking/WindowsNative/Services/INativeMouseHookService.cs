using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Services
{
    internal interface INativeMouseHookService : IDisposable
    {
        void Hook(Func<NativeMouseInput, bool> onMouseInput);
    }
}