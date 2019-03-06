using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Enums;
using Mmu.Mlh.NetFrameworkExtensions.Infrastructure.WindowsNative.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal sealed class NativeKeyboardHookService : INativeKeyboardHookService, IDisposable
    {
        private const int WmKeydown = 0x100;
        private const int WmKeyup = 0x101;
        private readonly IHookService _hookService;
        private Action<NativeKeyboardInput> _onKeyboardInput;

        public NativeKeyboardHookService(IHookService hookService)
        {
            _hookService = hookService;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Hook(Action<NativeKeyboardInput> onKeyboardInput)
        {
            _onKeyboardInput = onKeyboardInput;
            _hookService.Hook(HookType.KeyBoardLowLevel, OnHookReceived);
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
                case WmKeydown:
                {
                    _onKeyboardInput(new NativeKeyboardInput((Keys)longParam, NativeKeyboardInputDirection.KeyDown));
                }
                case WmKeyup:
                {
                    _onKeyboardInput(new NativeKeyboardInput((Keys)longParam, NativeKeyboardInputDirection.KeyUp));
                        break;
                }
            }
        }

        ~NativeKeyboardHookService()
        {
            Dispose(false);
        }
    }
}