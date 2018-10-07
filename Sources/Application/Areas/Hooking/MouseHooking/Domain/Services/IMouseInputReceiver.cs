using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Configuration;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.MouseHooking.Domain.Services
{
    public interface IMouseInputReceiver
    {
        MouseEventConfiguration Configuration { get; }

        Task ReceiveAsync(MouseInput input);
    }
}