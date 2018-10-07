using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Factories;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories
{
    internal interface IMouseInputFactory : IInputFactory<MouseInput, NativeMouseInput>
    {
    }
}