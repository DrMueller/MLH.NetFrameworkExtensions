using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Services;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardHookService : IKeyboardHookService
    {
        private readonly IKeyboardInputFactory _inputFactory;
        private readonly INativeKeyboardHookService _nativeKeyboardHookService;
        private readonly IKeyboardInputReceiver[] _receivers;

        public KeyboardHookService(
            INativeKeyboardHookService nativeKeyboardHookService,
            IKeyboardInputFactory inputFactory,
            IKeyboardInputReceiver[] receivers)
        {
            _nativeKeyboardHookService = nativeKeyboardHookService;
            _inputFactory = inputFactory;
            _receivers = receivers;
        }

        public void HookKeyboard()
        {
            _nativeKeyboardHookService.Hook(OnNativeKeyboardInput);
        }

        private void OnNativeKeyboardInput(NativeKeyboardInput nativeKeyboardInput)
        {
            var keyboardInput = _inputFactory.Create(nativeKeyboardInput);

            var receivingTasks = _receivers
                .Where(receiver => receiver.Configuration.CheckIfApplicable(keyboardInput))
                .Select(receiver => receiver.ReceiveAsync(keyboardInput))
                .ToArray();

            Task.Run(() => Task.WhenAll(receivingTasks));
        }
    }
}