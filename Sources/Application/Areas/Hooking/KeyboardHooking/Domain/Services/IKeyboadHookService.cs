using System;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services
{
    public interface IKeyboadHookService
    {
        void HookKeyboard(Action<KeyboardInput> onKeyboardInput);
    }
}