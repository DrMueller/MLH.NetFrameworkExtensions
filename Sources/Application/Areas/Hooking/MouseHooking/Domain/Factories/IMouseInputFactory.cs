using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.WindowsNative.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Factories
{
    internal interface IMouseInputFactory
    {
        MouseInput CreateFromNativeMouseInput(NativeMouseInput nativeMouseInput);
    }
}