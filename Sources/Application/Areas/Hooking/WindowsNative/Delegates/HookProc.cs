using System;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Delegates
{
    internal delegate IntPtr HookProc(int code, IntPtr wordParam, IntPtr longParam);
}