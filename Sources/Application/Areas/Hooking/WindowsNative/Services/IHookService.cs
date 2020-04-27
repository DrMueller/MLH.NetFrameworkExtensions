using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Delegates;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Enums;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Services
{
    internal interface IHookService : IDisposable
    {
        void Hook(HookType hookType, HookReceived hookReceivedCallback);
    }
}