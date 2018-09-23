using System;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardHookService : IKeyboardHookService
    {
        private readonly INativeKeyboardHookService _nativeKeyboardHookService;
        private readonly IKeyboardInputFactory _inputFactory;
        private Action<KeyboardInput> _onKeyboardInput;

        public KeyboardHookService(
            INativeKeyboardHookService nativeKeyboardHookService,
            IKeyboardInputFactory inputFactory)
        {
            _nativeKeyboardHookService = nativeKeyboardHookService;
            _inputFactory = inputFactory;
        }

        public void HookKeyboard(Action<KeyboardInput> onKeyboardInput)
        {
            _onKeyboardInput = onKeyboardInput;
            _nativeKeyboardHookService.Hook(OnNativeKeyboardInput);
        }

        private void OnNativeKeyboardInput(NativeKeyboardInput nativeKeyboardInput)
        {
            var keyboardInput = _inputFactory.CreateFromNativeKeyboardInput(nativeKeyboardInput);
            _onKeyboardInput(keyboardInput);
        }
    }
}