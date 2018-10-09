using System.Threading.Tasks;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models.Configurations;
using Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Models.Inputs;

namespace Mmu.Mlh.NetFrameworkExtensions.Areas.Hooking.Common.Services
{
    public interface IInputReceiver<TInput, TConfig>
        where TInput : IInput
        where TConfig : IEventConfiguration
    {
        TConfig Configuration { get; }

        Task<bool> ReceiveAsync(TInput input);
    }
}