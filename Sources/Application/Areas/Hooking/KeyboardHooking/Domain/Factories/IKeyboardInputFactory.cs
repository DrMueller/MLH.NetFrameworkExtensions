using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.WindowsNative.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories
{
    internal interface IKeyboardInputFactory : IInputFactory<KeyboardInput, NativeKeyboardInput>
    {
    }
}