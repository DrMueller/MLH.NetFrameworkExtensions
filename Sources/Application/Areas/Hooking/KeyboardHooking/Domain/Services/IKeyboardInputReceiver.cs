using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services
{
    public interface IKeyboardInputReceiver : IInputReceiver<KeyboardInput, KeyboardEventConfiguration>
    {
    }
}