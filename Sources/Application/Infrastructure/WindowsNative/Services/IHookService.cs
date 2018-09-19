using System;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Delegates;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Enums;

namespace Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Services
{
    internal interface IHookService : IDisposable
    {
        void Hook(HookType hookType, HookReceived hookReceivedCallback);
    }
}