using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Factories.Servants
{
    internal interface IKeyboardInputModifiersFactory
    {
        KeyboardInputModifiers Create();
    }
}