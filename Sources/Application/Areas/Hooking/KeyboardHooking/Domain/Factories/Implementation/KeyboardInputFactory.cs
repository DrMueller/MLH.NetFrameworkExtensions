using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StrcutureMap")]
    internal class KeyboardInputFactory : IKeyboardInputFactory
    {
        private readonly IKeyboardInputKeyMappingServant _inputKeyMappingServant;
        private readonly ILockOptionsFactory _lockOptionsFactory;
        private readonly IModifierOptionsFactory _modiferOptionsFactory;

        public KeyboardInputFactory(
            IKeyboardInputKeyMappingServant inputKeyMappingServant,
            ILockOptionsFactory lockOptionsFactory,
            IModifierOptionsFactory modiferOptionsFactory)
        {
            _inputKeyMappingServant = inputKeyMappingServant;
            _lockOptionsFactory = lockOptionsFactory;
            _modiferOptionsFactory = modiferOptionsFactory;
        }

        public KeyboardInput CreateFromNativeKeyboardInput(NativeKeyboardInput nativeKeyboardInput)
        {
            return new KeyboardInput(
                MapDirection(nativeKeyboardInput.Direction),
                _inputKeyMappingServant.MapFromNativeKey(nativeKeyboardInput.Key),
                _lockOptionsFactory.Create(),
                _modiferOptionsFactory.Create());
        }

        private static KeyboardInputDirection MapDirection(NativeKeyboardInputDirection native)
        {
            switch (native)
            {
                case NativeKeyboardInputDirection.KeyDown:
                {
                    return KeyboardInputDirection.KeyDown;
                }
                default:
                {
                    return KeyboardInputDirection.KeyUp;
                }
            }
        }
    }
}