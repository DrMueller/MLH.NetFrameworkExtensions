using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Configuration;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.KeyboardHooking.Domain.Services
{
    public interface IKeyboardInputReceiver
    {
        KeyboardEventConfiguration Configuration { get; }

        Task ReceiveAsync(KeyboardInput input);
    }
}