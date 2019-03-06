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
        private Action<NativeMouseInput> _onMouseInput;

        public NativeMouseHookService(IHookService hookService)
        {
            _hookService = hookService;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Hook(Action<NativeMouseInput> onMouseInput)
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

        private void OnHookReceived(int wordParam, int longParam)
        {
            switch (wordParam)
            {
                case WmLbuttondown:
                {
                    _onMouseInput(new NativeMouseInput(NativeMouseInputKey.Left, NativeMouseInputDirection.MouseDown));
                    break;
                }
                case WmLbuttonup:
                {
                    _onMouseInput(new NativeMouseInput(NativeMouseInputKey.Left, NativeMouseInputDirection.MouseUp));
                    break;
                }
                case WmRbuttondown:
                {
                    _onMouseInput(new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseDown));
                    break;
                }
                case WmRbuttonup:
                {
                    _onMouseInput(new NativeMouseInput(NativeMouseInputKey.Right, NativeMouseInputDirection.MouseUp));
                    break;
                }
            }
        }

        ~NativeMouseHookService()
        {
            Dispose(false);
        }
    }
}