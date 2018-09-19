using System;

namespace Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Delegates
{
    internal delegate IntPtr HookProc(int code, IntPtr wordParam, IntPtr longParam);
}