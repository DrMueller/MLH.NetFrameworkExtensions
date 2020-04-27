using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Delegates;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Enums;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Imports;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Services.Servants.Implementation;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.WindowsNative.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal sealed class HookService : IHookService
    {
        private HookProc _hookedProc;
        private MySafeHandle _hookId;
        private HookReceived _hookReceivedCallback;

        public HookService()
        {
            _hookedProc = HookProc;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Hook(HookType hookType, HookReceived hookReceivedCallback)
        {
            _hookReceivedCallback = hookReceivedCallback;
            _hookId = new MySafeHandle(NativeMethods.SetWindowsHookEx((int)hookType, _hookedProc, IntPtr.Zero, 0));
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _hookId.Dispose();
            }

            _hookedProc = null;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Runtime.InteropServices.SafeHandle.DangerousGetHandle", Justification = "I have no idea what I'm doing")]
        private IntPtr HookProc(int code, IntPtr wordParam, IntPtr longParam)
        {
            if (code < 0)
            {
                return NativeMethods.CallNextHookEx(_hookId.DangerousGetHandle(), code, wordParam, longParam);
            }

            var wordParamInt32 = wordParam.ToInt32();
            var longParamInt32 = Marshal.ReadInt32(longParam);
            _hookReceivedCallback(wordParamInt32, longParamInt32);

            return NativeMethods.CallNextHookEx(_hookId.DangerousGetHandle(), code, wordParam, longParam);
        }

        ~HookService()
        {
            Dispose(false);
        }
    }
}