using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services
{
    public interface IMouseHookService
    {
        void HookMouse(Action<MouseInput> onMouseInput);
    }
}