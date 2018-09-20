using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services.Implementation
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class MouseHookService : IMouseHookService
    {
        private readonly IMouseInputFactory _mouseInputFactory;
        private readonly INativeMouseHookService _nativeMouseHookService;
        private Action<MouseInput> _onMouseInput;

        public MouseHookService(INativeMouseHookService nativeMouseHookService, IMouseInputFactory mouseInputFactory)
        {
            _nativeMouseHookService = nativeMouseHookService;
            _mouseInputFactory = mouseInputFactory;
        }

        public void HookMouse(Action<MouseInput> onMouseInput)
        {
            _onMouseInput = onMouseInput;
            _nativeMouseHookService.Hook(OnNativeMouseInput);
        }

        private void OnNativeMouseInput(NativeMouseInput nativeMouseInput)
        {
            var mouseInput = _mouseInputFactory.CreateFromNativeMouseInput(nativeMouseInput);
            _onMouseInput(mouseInput);
        }
    }
}