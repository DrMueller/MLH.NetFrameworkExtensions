﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Delegates;

namespace Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Imports
{
    internal static class DllImports
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hookId, int code, IntPtr wordParam, IntPtr longParam);

        [DllImport("user32.dll")]
        internal static extern short GetKeyState(Keys key);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SetWindowsHookEx(
            int idHook,
            HookProc callback,
            IntPtr instance,
            uint threadId);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool UnhookWindowsHookEx(IntPtr instance);
    }
}