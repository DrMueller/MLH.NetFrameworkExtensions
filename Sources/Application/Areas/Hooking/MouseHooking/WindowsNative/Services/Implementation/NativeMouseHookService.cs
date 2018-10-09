using System;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Enums;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class NativeMouseHookService : INativeMouseHookService
    {
        private const int WmLbuttondown = 0x0201;
        private const int WmLbuttonup = 0x0202;
        private const int WmRbuttondown = 0x0204;
        private const int WmRbuttonup = 0x0205;
        private readonly IHookService _hookService;
        private Func<NativeMouseInput, bool> _onMouseInput;

        public NativeMouseHookService(IHookService hookService)
        {
            _hookService = hookService;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Hook(Func<NativeMouseInput, bool> onMouseInput)
        {
            _onMouseInput = onMouseInput;
            _hookService.Hook(HookType.MouseLowlevel, OnHookReceived);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _hookService.Dispose();
            }
        }

        private bool OnHookReceived(int wordParam, int longParam)
        {
            switch (wordParam)
            {
                case WmLbuttondown:
                {
                    return _onMouseInput(new NativeMouseInput(NativeMouseInputKey.Left, NativeMouseInputDirection.MouseDown));
                }
                case WmLbuttonup:
                {
                    return _onMouseInput(new NativeMouseInput(NativeMouseInputKey.Left, NativeMouseInputDirection.MouseUp));
                }
                case WmRbuttondown:
                {
                    return _onMouseInput(new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseDown));
                }
                case WmRbuttonup:
                {
                    return _onMouseInput(new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseUp));
                }
            }

            return true;
        }

        ~NativeMouseHookService()
        {
            Dispose(false);
        }
    }
}