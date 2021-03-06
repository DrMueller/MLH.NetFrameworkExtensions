﻿using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class MouseHookService : IMouseHookService
    {
        private readonly IMouseInputFactory _inputFactory;
        private readonly INativeMouseHookService _nativeMouseHookService;
        private readonly IMouseInputReceiver[] _receivers;

        public MouseHookService(
            INativeMouseHookService nativeMouseHookService,
            IMouseInputFactory inputFactory,
            IMouseInputReceiver[] receivers)
        {
            _nativeMouseHookService = nativeMouseHookService;
            _inputFactory = inputFactory;
            _receivers = receivers;
        }

        public void HookMouse()
        {
            _nativeMouseHookService.Hook(OnNativeMouseInput);
        }

        private void OnNativeMouseInput(NativeMouseInput nativeMouseInput)
        {
            var keyboardInput = _inputFactory.Create(nativeMouseInput);

            var receivingTasks = _receivers
                .Where(receiver => receiver.Configuration.CheckIfApplicable(keyboardInput))
                .Select(receiver => receiver.ReceiveAsync(keyboardInput))
                .ToArray();

            Task.Run(() => Task.WhenAll(receivingTasks));
        }
    }
}