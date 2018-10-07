using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Services;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services
{
    public interface IMouseInputReceiver : IInputReceiver<MouseInput, MouseEventConfiguration>
    {
    }
}