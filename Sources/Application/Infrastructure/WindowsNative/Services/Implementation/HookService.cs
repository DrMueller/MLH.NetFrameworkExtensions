using System;
using System.Runtime.InteropServices;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Delegates;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Enums;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Imports;

namespace Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Services.Implementation
{
    internal sealed class HookService : IHookService
    {
        private HookProc _hookedProc;
        private IntPtr _hookId = IntPtr.Zero;
        private HookReceived _hookReceivedCallback;

        public HookService()
        {
            _hookedProc = HookProc;
        }

        public void Dispose()
        {
            _hookedProc = null;
            _hookId = IntPtr.Zero;
            GC.SuppressFinalize(this);
        }

        public void Hook(HookType hookType, HookReceived hookReceivedCallback)
        {
            _hookReceivedCallback = hookReceivedCallback;
            _hookId = DllImports.SetWindowsHookEx((int)hookType, _hookedProc, IntPtr.Zero, 0);
        }

        private IntPtr HookProc(int code, IntPtr wordParam, IntPtr longParam)
        {
            if (code < 0)
            {
                return DllImports.CallNextHookEx(_hookId, code, wordParam, longParam);
            }

            var wordParamInt32 = wordParam.ToInt32();
            var longParamInt32 = Marshal.ReadInt32(longParam);
            _hookReceivedCallback(wordParamInt32, longParamInt32);

            return DllImports.CallNextHookEx(_hookId, code, wordParam, longParam);
        }

        ~HookService()
        {
            Dispose();
        }
    }
}