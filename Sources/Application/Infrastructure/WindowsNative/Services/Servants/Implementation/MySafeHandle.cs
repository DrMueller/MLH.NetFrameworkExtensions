using System;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;

namespace Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Services.Servants.Implementation
{
    internal class MySafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public MySafeHandle(IntPtr intPtr) : base(true)
        {
            SetHandle(intPtr);
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle()
        {
            handle = IntPtr.Zero;
            return true;
        }
    }
}